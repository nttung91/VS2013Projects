namespace Elca.Tools.ManorChangeScriptRunner
{
    public class DirectoryParameters
    {
        public string OracleHome { get; private set; }
        public string TnsProdu { get; private set; }
        public string TnsFis { get; private set; }
        public string TnsHaus { get; private set; }
        public string TnsMai { get; private set; }
        public string SqlPath { get; private set; }
        public string ScriptsExecutedDirectory { get; private set; }
        public string CopyForVietnamDirectory { get; private set; }

        public DirectoryParameters(string oracleHome, string tnsProdu, string tnsFis, string tnsHaus, string tnsMai, string sqlPath, string scriptsExecutedDir, string copyForVnDir)
        {
            OracleHome = oracleHome;
            TnsProdu = tnsProdu;
            TnsFis = tnsFis;
            TnsHaus = tnsHaus;
            TnsMai = tnsMai;
            SqlPath = sqlPath;
            ScriptsExecutedDirectory = scriptsExecutedDir;
            CopyForVietnamDirectory = copyForVnDir;
        }
    }
}