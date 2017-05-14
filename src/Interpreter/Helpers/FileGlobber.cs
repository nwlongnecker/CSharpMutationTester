using System.Collections.Generic;
using System.IO.Abstractions;

namespace Interpreter.Helpers
{
    class FileGlobber
    {
        public static List<string> ExpandFileGlob(string fileGlob, IFileSystem fileSystem)
        {
            var segments = fileGlob.Split('*');
            var files = new List<string>();
            if (segments.Length > 1)
            {
                //var dirs = Directory.GetDirectories(".", fileGlob);
                files.AddRange(fileSystem.Directory.GetFiles(segments[0], "*" + segments[1]));
            }
            return files;
        }
    }
}
