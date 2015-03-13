using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace Elca.Tools.ManorChangeScriptRunner.Framework
{
    class OracleHelper
    {
        public enum OracleVersion
        {
            Oracle9,
            Oracle10,
            Oracle0
        };

        private OracleVersion GetOracleVersion()
        {
            RegistryKey rgkLM = Registry.LocalMachine;
            RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\ALL_HOMES");

            /* 
             * 10g Installationen don't have an ALL_HOMES key
             * Try to find HOME at SOFTWARE\ORACLE\
             * 10g homes start with KEY_
             */
            string[] okeys = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE").GetSubKeyNames();
            foreach (string okey in okeys)
            {
                if (okey.StartsWith("KEY_"))
                    return OracleVersion.Oracle10;
            }

            if (rgkAllHome != null)
            {
                string strLastHome = "";
                object objLastHome = rgkAllHome.GetValue("LAST_HOME");
                strLastHome = objLastHome.ToString();
                RegistryKey rgkActualHome = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\HOME" + strLastHome);
                string strOraHome = "";
                object objOraHome = rgkActualHome.GetValue("ORACLE_HOME");
                string strOracleHome = strOraHome = objOraHome.ToString();
                return OracleVersion.Oracle9;
            }
            return OracleVersion.Oracle0;
        }

        public IEnumerable<string> GetOracleHomes()
        {
            RegistryKey rgkLM = Registry.LocalMachine;
            RegistryKey rgkAllHome = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\ALL_HOMES");
            OracleVersion ov = this.GetOracleVersion();

            switch (ov)
            {
                case OracleVersion.Oracle10:
                    {
                        string[] okeys = rgkLM.OpenSubKey(@"SOFTWARE\ORACLE").GetSubKeyNames();
                        foreach (string okey in okeys)
                        {
                            if (okey.StartsWith("KEY_"))
                            {
                                yield return rgkLM.OpenSubKey(@"SOFTWARE\ORACLE\" + okey).GetValue("ORACLE_HOME") as string;
                            }
                        }
                    }
                    break;
                default:
                    {
                        throw new Exception("No supported Oracle 10 Installation found");
                    }
            }
        }

        public List<string> LoadTNSNames(string oracleHomeDir)
        {
            List<string> DBNamesCollection = new List<string>();
            string RegExPattern = @"[\n][\s]*[^\(][a-zA-Z0-9_.]+[\s]*=[\s]*\(";
            string strTNSNAMESORAFilePath = Path.Combine(oracleHomeDir, @"NETWORK\ADMIN\TNSNAMES.ORA");

            if (!strTNSNAMESORAFilePath.Equals(""))
            {
                //check out that file does physically exists
                System.IO.FileInfo fiTNS = new System.IO.FileInfo(strTNSNAMESORAFilePath);
                if (fiTNS.Exists)
                {
                    if (fiTNS.Length > 0)
                    {
                        //read tnsnames.ora file
                        int iCount;
                        for (iCount = 0; iCount < Regex.Matches(
                            System.IO.File.ReadAllText(fiTNS.FullName),
                            RegExPattern).Count; iCount++)
                        {
                            DBNamesCollection.Add(Regex.Matches(
                                System.IO.File.ReadAllText(fiTNS.FullName),
                                RegExPattern)[iCount].Value.Trim().Substring(0,
                                Regex.Matches(System.IO.File.ReadAllText(fiTNS.FullName),
                                RegExPattern)[iCount].Value.Trim().IndexOf(" ")));
                        }
                    }
                }
            }
            return DBNamesCollection;
        }
    }
}
