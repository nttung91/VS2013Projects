namespace Elca.Tools.ManorChangeScriptRunner
{
    public class ExecutionResult
    {
        public ExecutionResult(ScriptResult log)
        {
            Log = log;
        }

        public string Output { get; set; }
        public ScriptResult Log { get; set; }

        public ExecutionResult(ScriptResult log, string output)
            : this(log)
        {
            Output = output;
        }
    }
}