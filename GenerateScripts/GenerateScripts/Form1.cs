using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateScripts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fDatabaseDbproxy2 = "F:\\Database\\DBPROXY2";


        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(fDatabaseDbproxy2));
            using (var sw = new StreamWriter("C:\\scripts.txt"))
            {
                foreach (var dir in dirs.OrderBy(x => x).ToList())
                {
                    if (!Directory.Exists(dir + "\\PRO")) continue;
                    var files =
                        from file in Directory.EnumerateFiles(dir + "\\PRO", "*.sql", SearchOption.AllDirectories)
                        where file.Contains("Spu ") || file.Contains("TableChange ")
                        select file;
                    if (files.Any())
                    {
                        sw.WriteLine(@"cd ""{0}""", Path.Combine(GetRealDir(dir), "PRO"));
                        var tableChanges = new List<string>();
                        var spuChanges = files.Where(x => x.Contains("Spu ")).ToList();
                        if (tableChanges.Any())
                        {
                            sw.WriteLine(@"sqlplus sys/DBAora2014@VKOPIES as sysdba;");
                            sw.WriteLine(@"SPOOL my_log_file2.log APPEND");
                            foreach (var tableChange in tableChanges)
                            {
                                sw.WriteLine(@"@""{0}""", Path.GetFileName(tableChange));
                            }
                            sw.WriteLine(@"SPOOL OFF");
                            sw.WriteLine(@"exit");
                        }

                        if (spuChanges.Any())
                        {
                            sw.WriteLine(@"sqlplus MIM_SPU/MIM_SPU@VKOPIES as sysdba;");
                            sw.WriteLine(@"SPOOL my_log_file2.log APPEND");
                            foreach (var spuChange in spuChanges)
                            {
                                sw.WriteLine(@"@""{0}""", Path.GetFileName(spuChange));
                            }
                            sw.WriteLine(@"SPOOL OFF");
                            sw.WriteLine(@"exit");
                        }
                    }
                }
            }

        }

        private string GetRealDir(string dir)
        {
            return dir.Replace(fDatabaseDbproxy2, "D:\\MANORPROXY\\DBPROXY2");
        }
    }
}
