using System.Collections.Generic;

namespace Interpreter.State
{
    public class InterpreterState
    {
        public IList<string> SourceFiles { get; set; }

        public InterpreterState()
        {
            SourceFiles = new List<string>();
        }

        internal bool AddSource(string file)
        {
            var alreadyContains = SourceFiles.Contains(file);
            if (!alreadyContains)
            {
                SourceFiles.Add(file);
            }
            return !alreadyContains;
        }
    }
}
