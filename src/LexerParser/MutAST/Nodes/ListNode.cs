namespace MutDSL.MutAST.Nodes
{
    public class ListNode : MutASTNode
    {
        public enum ListType
        {
            SOURCE,
            TEST
        }
        public ListType List_Type { get; }

        public ListNode(ListType listType)
        {
            List_Type = listType;
        }
    }
}
