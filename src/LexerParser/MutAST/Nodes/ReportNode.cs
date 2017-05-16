using System;
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

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as ReportNode;
            if (other == null) { return false; }
            return Report_Type.Equals(other.Report_Type) && ListsAreEqual(FileGlobs, other.FileGlobs);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "Report_Type", Report_Type.ToString() },
                { "FileGlobs", StringifyList(FileGlobs) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}