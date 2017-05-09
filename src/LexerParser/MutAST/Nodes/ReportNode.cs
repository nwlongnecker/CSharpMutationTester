namespace MutDSL.MutAST.Nodes
{
    public class ReportNode : MutASTNode
    {
        public enum ReportType
        {
            ALL,
            LAST
        }
        public ReportType Report_Type { get; }

        public ReportNode(ReportType reportType)
        {
            Report_Type = reportType;
        }
    }
}