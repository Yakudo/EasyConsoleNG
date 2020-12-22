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

        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue) => Console.Input.ReadInt(prompt, min: min, max: max);

        public static float ReadFloat(string prompt, float min = float.MinValue, float max = float.MaxValue) => Console.Input.ReadFloat(prompt, min: min, max: max);

        public static double ReadDouble(string prompt, double min = double.MinValue, double max = double.MaxValue) => Console.Input.ReadDouble(prompt, min: min, max: max);

        public static DateTime ReadDate(string prompt) => Console.Input.ReadDateTime(prompt);

        public static Uri ReadUrl(string prompt, UriKind uriKind = UriKind.Absolute) => Console.Input.ReadUrl(prompt, uriKind: uriKind);

        public static IPAddress ReadIpAddress(string prompt) => Console.Input.ReadIpAddress(prompt);

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable => Console.Input.ReadEnum<TEnum>(prompt);
    }
}
