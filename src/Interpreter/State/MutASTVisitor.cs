using MutDSL.MutAST;
using MutDSL.MutAST.Nodes;
using System.IO;

namespace Interpreter.State
{
    public class MutASTVisitor : AbstractMutASTVisitor<bool>
    {
        private InterpreterState interpreterState;

        public MutASTVisitor(InterpreterState interpreterState)
        {
            this.interpreterState = interpreterState;
        }

        public override bool Visit(AddNode addNode)
        {
            var successful = true;
            foreach(var fileGlob in addNode.FileGlobs)
            {
                if (!File.Exists(fileGlob))
                {
                    successful = false;
                    continue;
                }
                interpreterState.SourceFiles.Add(fileGlob);
            }
            return successful;
        }
    }
}
