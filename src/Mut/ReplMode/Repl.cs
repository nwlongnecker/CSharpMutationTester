using System;
using System.IO;

namespace Mut.ReplMode
{
    class Repl
    {
        private Output @out;
        private TextReader @in;

        public Repl(TextReader @in, Output @out)
        {
            this.@in = @in;
            this.@out = @out;
        }

        public void Start(bool shouldLoop = true)
        {
            string command = null;
            do
            {
                // prompt the user for a command
                @out.Prompt("> ");
                // Read the command from standard in
                try
                {
                    command = @in.ReadLine().Trim();
                }
                catch (IOException ioe)
                {
                    @out.Error(ioe.StackTrace);
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
                @out.Info("Parsing input");
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
            } while (shouldLoop);
        }
    }
}
