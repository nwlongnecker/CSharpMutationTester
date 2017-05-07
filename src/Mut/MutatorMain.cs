using System;
using System.IO;

namespace Mut
{
    public class MutatorMain
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to Mut, the Mutator DSL!");
                Repl(Console.In, Console.Out);
            }
            else
            {
                Console.WriteLine("Script mode not supported yet");
            }
        }

        private static void Repl(TextReader @in, TextWriter @out)
        {
            string command = null;
            while (true)
            {
                // prompt the user for a command
                @out.Write("> ");
                // Read the command from standard in
                try
                {
                    command = @in.ReadLine().Trim();
                }
                catch (IOException ioe)
                {
                    @out.WriteLine(ioe.StackTrace);
                    break;
                }
                // If the user wants to exit, exit
                if (string.Equals(command, "quit", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(command, "q", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(command, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                else if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }
                // Otherwise, attempt to parse the command
                @out.WriteLine("Parsing input");
                /*parser = LexerParserFactory.makeParser(new ANTLRInputStream(command));
                try
                {
                    tree = parser.command();
                    tree.accept(interpreter);
                }
                catch (Exception e)
                {
                    System.err.flush();
                    System.out.println(e.getMessage());
                    if (!out.equals(System.out)) {
					out.println(e.getMessage());
                    }
                }*/
            }
        }
    }
}
