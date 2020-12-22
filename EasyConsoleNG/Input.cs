using System;
using System.Net;

namespace EasyConsoleNG
{
    /// <summary>
    /// Static interface for (compatible with EasyConsole)
    /// </summary>
    public static class Input
    {
        private static EasyConsole Console => EasyConsole.Instance;

        public static string ReadString(string prompt) => Console.Input.ReadString(prompt);

        public static int ReadInt(string prompt, int min, int max) => Console.Input.ReadInt(prompt, min, max);
        public static int ReadInt(int min, int max) => Console.Input.ReadInt( min, max);
        public static int ReadInt() => Console.Input.ReadInt();

        public static float ReadFloat() => Console.Input.ReadFloat();

        public static double ReadDouble() => Console.Input.ReadDouble();

        public static DateTime ReadDate() => Console.Input.ReadDate();

        public static Uri ReadUrl(UriKind uriKind = UriKind.Absolute) => Console.Input.ReadUrl(uriKind);

        public static IPAddress ReadIpAddress() => Console.Input.ReadIpAddress();

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable => Console.Input.ReadEnum<TEnum>(prompt);
    }
}
