using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class MutateModulesNode : MutASTNode
    {
        public List<string> ModuleIds { get; }

        public MutateModulesNode(List<string> moduleIds)
        {
            ModuleIds = moduleIds;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as MutateModulesNode;
            if (other == null) { return false; }
            return ListsAreEqual(ModuleIds, other.ModuleIds);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "ModuleIds", StringifyList(ModuleIds) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
