using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    class MutFileNode : MutASTNode
    {
        public List<MutASTNode> Commands { get; }

        public MutFileNode(List<MutASTNode> commands)
        {
            Commands = commands;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
