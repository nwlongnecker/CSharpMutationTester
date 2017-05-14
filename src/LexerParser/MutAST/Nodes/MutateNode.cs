﻿using System;
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
    }
}
