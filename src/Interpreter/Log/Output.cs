using System;
using System.IO;

namespace Interpreter.Log
{
    public class Output
    {
        private TextWriter _writer;

        /// <summary>
        /// Class for controlling logging level and output stream
        /// </summary>
        public Output(TextWriter @out = null)
        {
            _writer = @out ?? Console.Out;
        }

        public void PromptLine(string prompt)
        {
            _writer.WriteLine(prompt);
        }

        public void Prompt(string prompt)
        {
            _writer.Write(prompt);
        }

        public void Info(string info)
        {
            _writer.WriteLine(info);
        }

        public void Error(string error)
        {
            _writer.WriteLine(error);
        }
    }
}