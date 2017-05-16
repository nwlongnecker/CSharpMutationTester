using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class ListNode : MutASTNode
    {
        public FileType ListType { get; }

        public ListNode(FileType listType)
        {
            ListType = listType;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as ListNode;
            if (other == null) { return false; }
            return ListType.Equals(other.ListType);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "ListType", ListType.ToString() }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
