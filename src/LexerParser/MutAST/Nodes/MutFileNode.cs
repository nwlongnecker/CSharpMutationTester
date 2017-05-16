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

        public override bool Equals(object obj)
        {
            var other = obj as MutFileNode;
            if (other == null) { return false; }
            return ListsAreEqual(Commands, other.Commands);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "Commands", StringifyList(Commands) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
