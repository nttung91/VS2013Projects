using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Elca.Tools.ManorChangeScriptRunner.Properties;

namespace Elca.Tools.ManorChangeScriptRunner
{
    public partial class FrmRunScriptVN : Form
    {
        public FrmRunScriptVN()
        {
            InitializeComponent();
        }

        public ScriptType GetScriptType()
        {
            if (ckSysDBA.Checked) return ScriptType.TableChange;
            if (ckSpu.Checked) return ScriptType.Spu;
            return ScriptType.TableChange;
        }

        public DatabaseType GetDatabase()
        {
            if (ckVKOPIES.Checked) return DatabaseType.PRO;
            if (ckVHAUTES.Checked) return DatabaseType.HAU;
            if (ckVFISTES.Checked) return DatabaseType.FIS;
            if (ckVMAITES.Checked) return DatabaseType.MAI;
            return DatabaseType.PRO;
        }

        private void sbExecute_Click(object sender, EventArgs e)
        {
            var startInfo = new ProcessStartInfo();
            var sysCall = GetScriptType() == ScriptType.TableChange ? GetSysLogin(GetDatabase(), Settings.Default) :
            GetSpuLogin(GetDatabase(), Settings.Default);

            var fileName = CreateFileWithContent(rtbSqlScript.Text);

            var call = string.Format("/C @echo exit | sqlplus {0} @{1}", sysCall, fileName);
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

            richTextBox2.Text = string.Join(Environment.NewLine, lines);


            if (proc != null && !proc.HasExited)
            {
                proc.Kill();
            }
        }

        private static string CreateFileWithContent(string p)
        {
            const string file = "sqlScript.sql";
            using (var sw = new StreamWriter(file))
            {
                sw.WriteLine(p);
                sw.Close();
            }
            return file;
        }

        private static string GetSpuLogin(DatabaseType databaseType, Settings settings)
        {
            var tns = GetTnsForDatabase(databaseType, settings);
            return string.Format("{0}/{1}@{2}", settings.MimSpuUser, settings.MimSpuPassword, tns);
        }

        private static string GetTnsForDatabase(DatabaseType databaseType, Settings dirs)
        {
            string tns;
            switch (databaseType)
            {
                case DatabaseType.FIS:
                    {
                        tns = dirs.TNSFis;
                        break;
                    }
                case DatabaseType.HAU:
                    {
                        tns = dirs.TNSHaus;
                        break;
                    }
                case DatabaseType.MAI:
                    {
                        tns = dirs.TNSMai;
                        break;
                    }
                default:
                    {
                        tns = dirs.TNSProdu;
                        break;
                    }
            }
            return tns;
        }

        private static string GetSysLogin(DatabaseType dirs, Settings settings)
        {
            var tns = GetTnsForDatabase(dirs, settings);
            return string.Format("{0}/{1}@{2} as sysdba", settings.SysUser, settings.SysPassword, tns);
        }

        private void sbPreview_Click(object sender, EventArgs e)
        {
            tcgResult.SelectedTabPage = lgResults;
        }

        private void FrmRunScriptVN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                sbExecute_Click(null, null);
            }
        }

    }
}
