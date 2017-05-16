using System;
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

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as MutateNode;
            if (other == null) { return false; }
            return ListsAreEqual(MutateFromSymbols, other.MutateFromSymbols) && ListsAreEqual(MutateToSymbols, other.MutateToSymbols);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "MutateFromSymbols", StringifyList(MutateFromSymbols) },
                { "MutateToSymbols", StringifyList(MutateToSymbols) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
