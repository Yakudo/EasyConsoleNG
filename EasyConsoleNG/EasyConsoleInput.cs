using System;
using System.Net;

namespace EasyConsoleNG
{
    public class EasyConsoleInput
    {
        private EasyConsole _console;

        public EasyConsoleInput(EasyConsole console)
        {
            _console = console;
        }

        public string ReadString(string prompt)
        {
            _console.Output.DisplayPrompt(prompt);
            return _console.ReadLine();
        }


        public string ReadString(string prompt, bool required = false, string defaultValue = null)
        {
            DisplayPromptWithDefaultValue(prompt, defaultValue);

            var value = _console.ReadLine();
            if (required)
            {
                while (string.IsNullOrWhiteSpace(value))
                {
                    _console.WriteLine("Value must not be empty.");
                    DisplayPromptWithDefaultValue(prompt, defaultValue);
                    value = _console.ReadLine();
                }
            }

            return !string.IsNullOrWhiteSpace(value) ? value : defaultValue;
        }

        public int ReadInt(string prompt, int min, int max)
        {
            _console.Output.DisplayPrompt(prompt);
            return ReadInt(min, max);
        }

        public int ReadInt(int min, int max)
        {
            var value = ReadInt();

            while (value < min || value > max)
            {
                _console.Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
                value = ReadInt();
            }

            return value;
        }

        public int ReadInt()
        {
            var input = _console.ReadLine();
            int value;

            while (!int.TryParse(input, out value))
            {
                _console.Output.DisplayPrompt("Please enter an integer");
                input = _console.ReadLine();
            }

            return value;
        }

        public float ReadFloat()
        {
            var input = _console.ReadLine();
            float value;

            while (!float.TryParse(input, out value))
            {
                _console.Output.DisplayPrompt("Please enter an floating point number");
                input = _console.ReadLine();
            }

            return value;
        }

        public double ReadDouble()
        {
            var input = _console.ReadLine();
            double value;

            while (!double.TryParse(input, out value))
            {
                _console.Output.DisplayPrompt("Please enter an floating point number");
                input = _console.ReadLine();
            }

            return value;
        }

        public DateTime ReadDate()
        {
            var input = _console.ReadLine();
            DateTime value;

            while (!DateTime.TryParse(input, out value))
            {
                _console.Output.DisplayPrompt("Please enter an datetime");
                input = _console.ReadLine();
            }

            return value;
        }

        public Uri ReadUrl(UriKind uriKind = UriKind.Absolute)
        {
            var input = _console.ReadLine();

            while (!Uri.IsWellFormedUriString(input, uriKind))
            {
                if (uriKind == UriKind.Absolute)
                {
                    _console.Output.DisplayPrompt("Please enter a valid absolute URL");
                }
                else if (uriKind == UriKind.Relative)
                {
                    _console.Output.DisplayPrompt("Please enter a valid absolute URL");
                }
                else
                {
                    _console.Output.DisplayPrompt("Please enter a valid URL");
                }
                input = _console.ReadLine();
            }

            return new Uri(input);
        }

        public IPAddress ReadIpAddress()
        {
            var input = _console.ReadLine();
            IPAddress value;

            while (!IPAddress.TryParse(input, out value))
            {
                _console.Output.DisplayPrompt("Please enter a valid IP Address");
                input = _console.ReadLine();
            }

            return value;
        }

        public TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var type = typeof(TEnum);

            if (!type.IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

            _console.WriteLine(prompt);
            var menu = new Menu();

            var choice = default(TEnum);
            foreach (var value in Enum.GetValues(type))
                menu.Add(Enum.GetName(type, value), () => { choice = (TEnum)value; });
            menu.Display();

            return choice;
        }

        #region Utils

        protected void DisplayPromptWithDefaultValue(string prompt, object defaultValue)
        {
            if (defaultValue != null)
            {
                prompt = prompt.Trim().TrimEnd(':');
                prompt = $"{prompt} (default: {defaultValue})";
            }
            _console.Output.DisplayPrompt(prompt);
        }
        #endregion
    }
}
