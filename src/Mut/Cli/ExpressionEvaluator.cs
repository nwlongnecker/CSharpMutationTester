using Antlr4.Runtime;
using Mut.Interpreter;
using Mut.Interpreter.Actions;

namespace Mut.Cli
{
    class ExpressionEvaluator
    {
        public static MutActionBase SingleEval(string command, CommandVisitor interpreter)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return new MutActionBase();
            }
            var lexer = new MutatorLexer(new AntlrInputStream(command));
            lexer.AddErrorListener(new MutLexerErrorListener());
            var parser = new MutatorParser(new CommonTokenStream(lexer));
            parser.AddErrorListener(new MutParserErrorListener());
            var tree = parser.command();
            return tree.Accept(interpreter);
        }

        public static MutActionBase SingleEval(string command, InterpreterState state = null)
        {
            var interpreter = new CommandVisitor(state ?? new InterpreterState());
            return SingleEval(command, interpreter);
        }
    }
}
