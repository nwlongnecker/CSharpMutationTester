namespace MutDSL.MutAST.Nodes
{
    public class ListNode : MutASTNode
    {
        public FileType ListType { get; }

        public ListNode(FileType listType)
        {
            ListType = listType;
        }
    }
}
