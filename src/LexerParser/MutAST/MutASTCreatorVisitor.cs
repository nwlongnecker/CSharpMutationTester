using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LexerParser.LexParse;
using MutDSL.MutAST.Nodes;
using System;

namespace MutDSL.MutAST
{
    class MutASTCreatorVisitor : IMutatorVisitor<MutASTNode>
    {
        public MutASTNode Visit(IParseTree tree)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitAddSource([NotNull] MutatorParser.AddSourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitAddTest([NotNull] MutatorParser.AddTestContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitCommand([NotNull] MutatorParser.CommandContext context)
        {
            // Command should never have more than one child. The lexer should split such input into separate commands.
            return context.GetChild(0).Accept(this);
        }

        public MutASTNode VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitFileList([NotNull] MutatorParser.FileListContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitIdList([NotNull] MutatorParser.IdListContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitListSource([NotNull] MutatorParser.ListSourceContext context)
        {
            return new ListSourceNode();
        }

        public MutASTNode VisitListTest([NotNull] MutatorParser.ListTestContext context)
        {
            return new ListTestNode();
        }

        public MutASTNode VisitMutate([NotNull] MutatorParser.MutateContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitMutFile([NotNull] MutatorParser.MutFileContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitRemoveSource([NotNull] MutatorParser.RemoveSourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitRemoveTest([NotNull] MutatorParser.RemoveTestContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitReport([NotNull] MutatorParser.ReportContext context)
        {
            // Default to only reporting the last test
            var reportType = ReportNode.ReportType.LAST;
            if (context.ALL() != null)
            {
                reportType = ReportNode.ReportType.ALL;
            }
            return new ReportNode(reportType);
        }

        public MutASTNode VisitSource([NotNull] MutatorParser.SourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitStrain([NotNull] MutatorParser.StrainContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitSymbolList([NotNull] MutatorParser.SymbolListContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitTest([NotNull] MutatorParser.TestContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitUse([NotNull] MutatorParser.UseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
