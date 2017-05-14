using MutDSL.MutAST;
using MutDSL.MutAST.Nodes;
using Interpreter.Helpers;
using System.IO.Abstractions;

namespace Interpreter.State
{
    public class MutASTVisitor : AbstractMutASTVisitor<bool>
    {
        private InterpreterState interpreterState;
        private IFileSystem fileSystem;

        public MutASTVisitor(InterpreterState interpreterState, IFileSystem fileSystem)
        {
            this.interpreterState = interpreterState;
            this.fileSystem = fileSystem;
        }

        public override bool Visit(AddNode addNode)
        {
            var successful = true;
            foreach(var fileGlob in addNode.FileGlobs)
            {
                if (fileSystem.File.Exists(fileGlob))
                {
                    // Return false if any of the files were unsuccessfully added
                    successful = successful && interpreterState.AddSource(fileGlob);
                }
                else
                {
                    var files = FileGlobber.ExpandFileGlob(fileGlob, fileSystem);
                    foreach (var file in files)
                    {
                        if (!fileSystem.File.Exists(file))
                        {
                            successful = false;
                        }
                        else
                        {
                            // Return false if any of the files were unsuccessfully added
                            successful = successful && interpreterState.AddSource(file);
                        }
                    }
                }
            }
            return successful;
        }
    }
}
