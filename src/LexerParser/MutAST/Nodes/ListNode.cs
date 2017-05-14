using System;

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
    }
}
