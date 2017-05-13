﻿using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class RemoveNode : MutASTNode
    {
        public FileType RemoveType { get; }
        public List<string> FileGlobs { get; }

        public RemoveNode(FileType removeType, List<string> fileGlobs)
        {
            RemoveType = removeType;
            FileGlobs = fileGlobs;
        }
    }
}
