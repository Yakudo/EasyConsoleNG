using System;

namespace EasyConsoleNG
{
    /// <summary>
    /// Static interface for (compatible with EasyConsole)
    /// </summary>
    public static class Output
    {
        private static EasyConsole Console => EasyConsole.Instance;

        public static void WriteLine(ConsoleColor color, string format, params object[] args) => Console.Output.WriteLine(color, format, args);

        public static void WriteLine(ConsoleColor color, string value) => Console.Output.WriteLine(color, value);

        public static void WriteLine(string format, params object[] args) => Console.Output.WriteLine(format, args);

        public static void DisplayPrompt(string format, params object[] args) => Console.Output.WriteLine(format, args);
    }
}
