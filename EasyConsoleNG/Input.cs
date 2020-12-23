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

        public static string ReadString(string prompt, string defaultValue = null) => Console.Input.ReadString(prompt, defaultValue: defaultValue);

        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue, int defaultValue = 0) => Console.Input.ReadInt(prompt, min: min, max: max, defaultValue: defaultValue);

        public static float ReadFloat(string prompt, float min = float.MinValue, float max = float.MaxValue, float defaultValue = 0f) => Console.Input.ReadFloat(prompt, min: min, max: max, defaultValue: defaultValue);

        public static double ReadDouble(string prompt, double min = double.MinValue, double max = double.MaxValue, double defaultValue = 0) => Console.Input.ReadDouble(prompt, min: min, max: max, defaultValue: defaultValue);

        public static DateTime ReadDate(string prompt) => Console.Input.ReadDateTime(prompt);

        public static Uri ReadUrl(string prompt, UriKind uriKind = UriKind.Absolute) => Console.Input.ReadUrl(prompt, uriKind: uriKind);

        public static IPAddress ReadIpAddress(string prompt) => Console.Input.ReadIpAddress(prompt);

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable => Console.Input.ReadEnum<TEnum>(prompt);
    }
}
