using System;
using Antlr4.Runtime.Tree;
using Mut.Interpreter.Actions;

namespace Mut.Interpreter
{
    class CommandVisitor : IMutatorVisitor<MutActionBase>
    {
        private InterpreterState _state;
        public CommandVisitor(InterpreterState state)
        {
            _state = state;
        }
        public MutActionBase Visit(IParseTree tree)
        {
            throw new NotImplementedException("Unrecognized command");
        }

        public MutActionBase VisitAddSource(MutatorParser.AddSourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitAddTest(MutatorParser.AddTestContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitCommand(MutatorParser.CommandContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitFileList(MutatorParser.FileListContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitIdList(MutatorParser.IdListContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitListSource(MutatorParser.ListSourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitListTest(MutatorParser.ListTestContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitMutate(MutatorParser.MutateContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitMutFile(MutatorParser.MutFileContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitRemoveSource(MutatorParser.RemoveSourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitRemoveTest(MutatorParser.RemoveTestContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitReport(MutatorParser.ReportContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitSource(MutatorParser.SourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitStrain(MutatorParser.StrainContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitSymbolList(MutatorParser.SymbolListContext context)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException();
        }

        public MutActionBase VisitTest(MutatorParser.TestContext context)
        {
            //context.fileList()
            return new TestAction();
        }

        public MutActionBase VisitUse(MutatorParser.UseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
