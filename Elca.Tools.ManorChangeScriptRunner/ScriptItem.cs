using System;

namespace Elca.Tools.ManorChangeScriptRunner
{
    public class ScriptItem
    {
        public DatabaseType Database { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public DateTime DateTime { get; set; }
        public ScriptType ScriptType { get; set; }

        public bool HasNewerLater { get; set; }
    }
}