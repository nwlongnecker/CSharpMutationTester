using System;
using System.Collections.Generic;
using System.Linq;

namespace MutDSL.MutAST.Nodes
{
    class ModuleNode : MutASTNode
    {
        public string Id { get; }
        public List<MutASTNode> Mutations { get; }

        public ModuleNode(string id, List<MutASTNode> mutations)
        {
            Id = id;
            Mutations = mutations;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as ModuleNode;
            if (other == null) { return false; }
            return Id.Equals(other.Id) && ListsAreEqual(Mutations, other.Mutations);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "Id", Id.ToString() },
                { "Mutations", StringifyList(Mutations) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
