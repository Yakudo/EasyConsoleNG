using System;

namespace EasyConsoleNG
{
    public class EasyConsoleOutput
    {
        private EasyConsole _console;

        public EasyConsoleOutput(EasyConsole console)
        {
            _console = console;
        }

        public void WriteLine(ConsoleColor color, string format, params object[] args)
        {
            _console.ForegroundColor = color;
            _console.WriteLine(format, args);
            _console.ResetColor();
        }

        public void WriteLine(ConsoleColor color, string value)
        {
            _console.ForegroundColor = color;
            _console.WriteLine(value);
            _console.ResetColor();
        }

        public void WriteLine(string format, params object[] args)
        {
            _console.WriteLine(format, args);
        }

        public void DisplayPrompt(string format, params object[] args)
        {
            format = format.Trim().TrimEnd(':') + ": ";
            _console.Write(format, args);
        }
    }
}
