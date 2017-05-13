using System.Collections.Generic;

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
        public List<string> FileGlobs { get; }

        public ReportNode(ReportType reportType, List<string> fileGlobs)
        {
            Report_Type = reportType;
            FileGlobs = fileGlobs;
        }
    }
}