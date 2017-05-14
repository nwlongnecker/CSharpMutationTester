﻿using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    class ModuleNode : MutASTNode
    {
        public List<MutASTNode> Mutations { get; }
        public string Id { get; }

        public ModuleNode(string id, List<MutASTNode> mutations)
        {
            Id = id;
            Mutations = mutations;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
