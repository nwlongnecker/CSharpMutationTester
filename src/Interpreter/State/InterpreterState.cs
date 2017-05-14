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
    }
}
