﻿using LexerParser.LexParse;
using Mut.Interpreter;
using Mut.Log;
using System;
using System.IO;

namespace Mut.Cli
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
            var interpreter = new CommandVisitor();
            do
            {
                // prompt the user for a command
                @out.Prompt("> ");
                // Read the command from the input stream
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

                // Otherwise, attempt to parse the command
                try
                {
                    var ast = CommandToMutASTConverter.Convert(command);
                    ast.Accept(interpreter);
                }
                catch (Exception e)
                {
                    @out.Error(e.Message);
                    @out.Error(e.StackTrace);
                }
            } while (shouldLoop);
        }
    }
}
