using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using DevExpress.Utils.Controls;
using DevExpress.XtraPrinting.Native;
using Elca.Tools.ManorChangeScriptRunner.Properties;

namespace Elca.Tools.ManorChangeScriptRunner
{
    public class ScriptHandler
    {
        public readonly static string[] MpkDataGeneratorSql = { "MPK_WWS_DATA_GENERATOR.SQL", "MPK_HAU_DATA_GENERATOR.SQL" };

        public ExecutionResult Execute(ScriptItem item, DirectoryParameters dirs, ScriptExecutionType howTo)
        {
            if (howTo == ScriptExecutionType.Skip)
            {
                return Skip(item, dirs);
            }

            string totalOutput = string.Empty;
            if (howTo == ScriptExecutionType.ExecuteAndMove || howTo == ScriptExecutionType.ExecuteOnly)
            {
                if (item.ScriptType == ScriptType.DataGeneratorSpu)
                {
                    string content = File.ReadAllText(item.FullPath);
                    content = content.Replace("'PKOPIE'", "'VKOPIES'");
                    content = content.Replace("'FISTES'", "'VFISTES'");
                    content = content.Replace("'HAUTES'", "'VHAUTES'");
                    content = content.Replace("'MAITES'", "'VMAITES'");

                    content = content.Replace("gcv_valid_db_for_generator CONSTANT VARCHAR2(6)", "gcv_valid_db_for_generator CONSTANT VARCHAR2(7)");

                    File.WriteAllText(item.FullPath, content);
                }
                else if (item.ScriptType == ScriptType.DropSpu)
                {
                    var spuName = item.Name.ToUpper().Replace("DELETE_", string.Empty).Replace(".SQL", string.Empty);
                    var text = File.ReadAllText("DropSpu.txt");
                    var sql = string.Format(text, "MIM_SPU", spuName.ToUpper());
                    File.WriteAllText(item.FullPath, sql);
                }

                var startInfo = new ProcessStartInfo();
                startInfo.EnvironmentVariables["ORACLE_HOME"] = dirs.OracleHome;
                startInfo.EnvironmentVariables["TNS_ADMIN"] = Path.Combine(dirs.OracleHome, Path.Combine("network", "admin"));
                startInfo.EnvironmentVariables["SQLPATH"] = dirs.SqlPath;

                var settings = Settings.Default;
                string call;
                if (item.ScriptType == ScriptType.TableChange || item.ScriptType == ScriptType.DropSpu)
                {
                    var sysCall = GetSysLogin(dirs, settings, item);
                    call = string.Format("/C @echo exit | sqlplus {0} @EXEC_DM_RELEASE \"{1}\"", sysCall, item.FullPath);
                }
                else
                {
                    var spuName = GetSpuName(item);

                    string spuUser;
                    string spuCall;
                    if (item.ScriptType == ScriptType.DataGeneratorSpu && item.Database == DatabaseType.PRO)
                    {
                        spuUser = "MIM_DATA_GENERATOR";
                        spuCall = GetSysLogin(dirs, settings, item);
                    }
                    else
                    {
                        spuUser = "MIM_SPU";
                        spuCall = GetSpuLogin(dirs, settings, item);
                    }


                    call = string.Format("/C @echo exit | sqlplus {0} @EXEC_SPU  \"{1}\" {2} {3}", spuCall, item.FullPath, spuUser, spuName);
                }

                startInfo.UseShellExecute = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = call;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;

                var proc = Process.Start(startInfo);

                var lines = new List<string>();
                while (proc != null && !proc.StandardOutput.EndOfStream)
                {
                    lines.Add(proc.StandardOutput.ReadLine());
                }

                totalOutput = string.Join(Environment.NewLine, lines);

                // Don't be confused by "SHOW ERRORS"
                if (totalOutput.Replace("SHOW ERRORS", string.Empty).Replace("WHENEVER SQLERROR", string.Empty).Contains("ERROR"))
                {
                    return new ExecutionResult(ScriptResult.Error, totalOutput);
                }

                foreach (string line in lines)
                {
                    if (line.StartsWith("SP2-") || line.StartsWith("Warning: "))
                    {
                        // Ignore certain error
                        if (line.StartsWith("SP2-0310") && line.Contains("oe_global:release4elca.sql"))
                        {
                            continue;
                        }

                        return new ExecutionResult(ScriptResult.Error, totalOutput);
                    }
                }

                if (proc != null && !proc.HasExited)
                {
                    proc.Kill();
                    return new ExecutionResult(ScriptResult.Error, totalOutput + Environment.NewLine + "PROCESS NOT EXITED");
                }
            }

            if (howTo != ScriptExecutionType.ExecuteOnly)
            {
                try
                {
                    CreateScriptFileForVietnam(item, dirs.CopyForVietnamDirectory);
                    MoveFile(item, dirs.ScriptsExecutedDirectory, false);
                }
                catch (Exception e)
                {
                    return new ExecutionResult(ScriptResult.Error, e.Message);
                }
            }

            return new ExecutionResult(ScriptResult.Executed, totalOutput);
        }

        private static string GetSpuLogin(DirectoryParameters dirs, Settings settings, ScriptItem item)
        {
            var tns = GetTnsForDatabase(dirs, item);
            return string.Format("{0}/{1}@{2}", settings.MimSpuUser, settings.MimSpuPassword, tns);
        }

        private static string GetTnsForDatabase(DirectoryParameters dirs, ScriptItem item)
        {
            string tns;
            switch (item.Database)
            {
                case DatabaseType.FIS:
                    {
                        tns = dirs.TnsFis;
                        break;
                    }
                case DatabaseType.HAU:
                    {
                        tns = dirs.TnsHaus;
                        break;
                    }
                case DatabaseType.MAI:
                    {
                        tns = dirs.TnsMai;
                        break;
                    }
                default:
                    {
                        tns = dirs.TnsProdu;
                        break;
                    }
            }
            return tns;
        }

        private static string GetSysLogin(DirectoryParameters dirs, Settings settings, ScriptItem item)
        {
            var tns = GetTnsForDatabase(dirs, item);
            return string.Format("{0}/{1}@{2} as sysdba", settings.SysUser, settings.SysPassword, tns);
        }

        private static string GetSpuName(ScriptItem item)
        {
            return new FileInfo(item.FullPath).Name.ToUpper().Replace(".SQL", string.Empty);
        }

        private void CreateScriptFileForVietnam(ScriptItem item, string copyForVnDirectory)
        {
            var fileContent = File.ReadAllLines(item.FullPath);
            var newFile = new StringBuilder();
            var targetDir = copyForVnDirectory;

            // Treat the same
            if (item.ScriptType == ScriptType.DropSpu)
            {
                item.ScriptType = ScriptType.TableChange;
            }

            if (item.ScriptType == ScriptType.TableChange)
            {
                // Remove "START header/footer" lines
                foreach (var line in fileContent.Select(p => p.TrimStart()))
                {
                    if (line.StartsWith("START header", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    if (line.StartsWith("START footer", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    if (line.StartsWith("@oe_global:release4elca.sql", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }
                    newFile.AppendLine(line);
                }
            }
            else
            {
                if (item.ScriptType == ScriptType.DataGeneratorSpu)
                {
                    // Take full script
                    fileContent.ForEach(p => newFile.AppendLine(p.Replace("'EPKOPIE'", "'VPKOPIE'").
                                                                  Replace("'EFISTES'", "'VFISTES'").
                                                                  Replace("'EHAUTES'", "'VHAUTES'").
                                                                  Replace("'EMAITES'", "'VMAITES'")));
                }
                else
                {
                    // Take full script
                    fileContent.ForEach(p => newFile.AppendLine(p));
                }

                newFile.AppendLine("/");

                var spuName = GetSpuName(item);
                var spuUser = (item.ScriptType == ScriptType.Spu) ? "MIM_SPU" : "MIM_DATA_GENERATOR";
                var grant = string.Format("start grant_object {0} {1} debug;", spuUser, spuName);
                newFile.AppendLine(grant);
            }

            //VN Folder exists?
            CheckDirectoryExists(targetDir);

            targetDir = Path.Combine(targetDir, item.DateTime.ToString("yyyy-MM-dd"));
            //Day Folder exists?
            CheckDirectoryExists(targetDir);

            targetDir = Path.Combine(targetDir, item.Database.ToString().ToUpper());
            //Database Folder exists?
            CheckDirectoryExists(targetDir);

            var fileName = string.Format("{0} {1}", item.ScriptType, item.Name);
            var filePath = Path.Combine(targetDir, fileName);

            File.WriteAllText(filePath, newFile.ToString());
        }

        private static void CheckDirectoryExists(string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }
        }

        private ExecutionResult Skip(ScriptItem item, DirectoryParameters dirs)
        {
            try
            {
                MoveFile(item, dirs.ScriptsExecutedDirectory, true);
            }
            catch (Exception e)
            {
                return new ExecutionResult(ScriptResult.Error, e.Message);
            }
            return new ExecutionResult(ScriptResult.Skipped);
        }

        private void MoveFile(ScriptItem item, string targetDirectory, bool isSkip)
        {
            var fileInfo = new FileInfo(item.FullPath);
            var dayParent = fileInfo.Directory;
            if (dayParent != null)
            {
                var newDirectory = Path.Combine(targetDirectory, dayParent.Name);

                var newFileName = string.Format("{0} {1}", item.Database, fileInfo.Name);
                var newFilePath = Path.Combine(newDirectory, newFileName);

                Directory.CreateDirectory(newDirectory);
                File.Move(item.FullPath, newFilePath);
                if (fileInfo.Directory != null) RemoveParentsIfEmpty(fileInfo.Directory.FullName);

                if (isSkip)
                {
                    var renamedFileInfo = new FileInfo(newFilePath);
                    var renamedFilePath = renamedFileInfo.FullName.Replace(renamedFileInfo.Extension, ".skipped");
                    File.Move(newFilePath, renamedFilePath);
                }
            }
        }

        private void RemoveParentsIfEmpty(string directory)
        {
            var parent = Directory.GetParent(directory).FullName;
            if (IsDirectoryEmpty(directory))
            {
                Directory.Delete(directory);
            }
            if (IsDirectoryEmpty(parent))
            {
                Directory.Delete(parent);
            }
        }

        private bool IsDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}
