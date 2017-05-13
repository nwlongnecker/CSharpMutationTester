using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class MutateNode : MutASTNode
    {
        public List<string> MutateFromSymbols { get; }
        public List<string> MutateToSymbols { get; }

        public MutateNode(List<string> mutateFromSymbols, List<string> mutateToSymbols)
        {
            MutateFromSymbols = mutateFromSymbols;
            MutateToSymbols = mutateToSymbols;
        }
    }
}
