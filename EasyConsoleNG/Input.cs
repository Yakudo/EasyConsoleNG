using System;
using System.Net;

namespace EasyConsoleNG
{
    public static class Input
    {

        public static string ReadString(string prompt)
        {
            Output.DisplayPrompt(prompt);
            return Console.ReadLine();
        }

        public static int ReadInt(string prompt, int min, int max)
        {
            Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public static int ReadInt(int min, int max)
        {
            var value = ReadInt();

            while (value < min || value > max)
            {
                Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public static int ReadInt()
        {
            var input = Console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an integer");
                input = Console.ReadLine();
            }

            return value;
        }

        public static float ReadFloat()
        {
            var input = Console.ReadLine();
            float value;

            while (!float.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an floating point number");
                input = Console.ReadLine();
            }

            return value;
        }

        public static double ReadDouble()
        {
            var input = Console.ReadLine();
            double value;

            while (!double.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an floating point number");
                input = Console.ReadLine();
            }

            return value;
        }

        public static DateTime ReadDate()
        {
            var input = Console.ReadLine();
            DateTime value;

            while (!DateTime.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter an datetime");
                input = Console.ReadLine();
            }

            return value;
        }

        public static Uri ReadUrl(UriKind uriKind = UriKind.Absolute)
        {
            var input = Console.ReadLine();

            while (!Uri.IsWellFormedUriString(input, uriKind))
            {
                if(uriKind == UriKind.Absolute)
                {
                    Output.DisplayPrompt("Please enter a valid absolute URL");
                }else if(uriKind == UriKind.Relative)
                {
                    Output.DisplayPrompt("Please enter a valid absolute URL");
                }
                else
                {
                    Output.DisplayPrompt("Please enter a valid URL");
                }
                input = Console.ReadLine();
            }

            return new Uri(input);
        }

        public static IPAddress ReadIpAddress(UriKind uriKind = UriKind.Absolute)
        {
            var input = Console.ReadLine();
            IPAddress value;

            while (!IPAddress.TryParse(input, out value))
            {
                Output.DisplayPrompt("Please enter a valid IP Address");
                input = Console.ReadLine();
            }

            return value;
        }

        public static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var type = typeof(TEnum);

            if (!type.IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

            Output.WriteLine(prompt);
            var menu = new Menu();

            var choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }
    }
}
