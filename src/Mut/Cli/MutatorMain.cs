using Interpreter.Log;
using System;

namespace Mut.Cli
{
    public class MutatorMain
    {
        public static Output Output { get; set; } = new Output();

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Output.PromptLine("Welcome to Mut, the Mutator DSL!");
                var repl = new Repl(Console.In, Output);
                repl.Start();
            }
            else
            {
                Output.Info("Executing script " + args[0]);
            }
        }
    }
}
