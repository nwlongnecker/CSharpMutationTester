using MutDSL.MutAST;
using MutDSL.MutAST.Nodes;
using System.IO;
using Interpreter.Log;

namespace Interpreter.State
{
    public class MutASTVisitor : AbstractMutASTVisitor<bool>
    {
        private InterpreterState interpreterState;
        private Output @out;

        public MutASTVisitor(InterpreterState interpreterState, Output @out)
        {
            this.interpreterState = interpreterState;
            this.@out = @out;
        }

        public override bool Visit(AddNode addNode)
        {
            var successful = true;
            foreach(var fileGlob in addNode.FileGlobs)
            {
                if (!File.Exists(fileGlob))
                {
                    // TODO: We only support adding full paths for now
                    successful = false;
                    continue;
                }
                interpreterState.SourceFiles.Add(fileGlob);
                @out.Info("Added " + fileGlob + " to source");
            }
            return successful;
        }
    }
}
