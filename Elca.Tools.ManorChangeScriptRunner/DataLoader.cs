using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Elca.Tools.ManorChangeScriptRunner
{
    public class DataLoader
    {
        private static readonly Regex RegexTableChange1 = new Regex(@"M\d{6}\w_UPDATE\.SQL", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex RegexTableChange2 = new Regex(@"^\d\d_.*\.SQL", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex RegexDropSpu = new Regex(@"DELETE_[\d\w_]+.SQL", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private readonly string[] _dbDirNames = { "FIS", "HAU", "MAI", "PRO", "FSC" };

        public IEnumerable<ScriptItem> GetScriptsToExecute(string scriptsDir)
        {
            if (Directory.Exists(scriptsDir))
            {
                // Get the folders we're interested in
                var dbDirs = Directory.EnumerateDirectories(scriptsDir).Where(p => _dbDirNames.Contains(new DirectoryInfo(p).Name));

                var files = dbDirs.SelectMany(p => Directory.EnumerateFiles(p, "*.sql", SearchOption.AllDirectories));
                foreach (var file in files)
                {
                    var fileInfo = new FileInfo(file);
                    var item = new ScriptItem();
                    item.FullPath = fileInfo.FullName;
                    item.Name = fileInfo.Name;

                    var dateParent = fileInfo.Directory;
                    if (dateParent != null)
                    {
                        var dbParent = dateParent.Parent;
                        DatabaseType databaseType;

                        if (dbParent != null && Enum.TryParse(dbParent.Name, true, out databaseType))
                        {
                            item.Database = databaseType;
                        }
                        else
                        {
                            continue;
                        }

                        item.DateTime = DateTime.Parse(dateParent.Name);
                    }


                    if (RegexTableChange1.IsMatch(item.Name) || RegexTableChange2.IsMatch(item.Name))
                    {
                        item.ScriptType = ScriptType.TableChange;
                    }
                    else if (RegexDropSpu.IsMatch(item.Name))
                    {
                        item.ScriptType = ScriptType.DropSpu;
                    }
                    else if (ScriptHandler.MpkDataGeneratorSql.Any(p => p.Equals(item.Name, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        item.ScriptType = ScriptType.DataGeneratorSpu;
                    }
                    else
                    {
                        item.ScriptType = ScriptType.Spu;
                    }

                    yield return item;

                }
            }
        }
    }
}
