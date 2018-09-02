using HelloWorld.Interfaces;
using System;

namespace HelloWorld.Utilities
{
    /// <summary>
    /// Implementation of the ITextWriter interface for writing out to the Console
    /// </summary>
    public class ConsoleWriter : ITextWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
