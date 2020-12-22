using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Moq;

namespace EasyConsoleNG.Tests
{
    public class TestEasyConsole : EasyConsole
    {
        public TestEasyConsole() : base()
        {
            OutputWriter = new StringWriter();
        }

        internal void SetupInput(string value)
        {
            InputReader = new StringReader(value);
        }

        public object CapturedOutput => OutputWriter.ToString().Replace("\r", "");
    }
}
