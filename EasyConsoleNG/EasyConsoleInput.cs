using System;
using System.Net;

namespace EasyConsoleNG
{
    public delegate string Converter<T>(string rawValue, out T value);

    public static class Converters
    {
        public static string ToString(string rawValue, out string value)
        {
            value = rawValue;
            return null;
        }

        public static string ToInt(string rawValue, out int value)
        {
            if(!int.TryParse(rawValue, out value))
            {
                return "Please enter a valid integer";
            }
            return null;
        }

        public static string ToNullableInt(string rawValue, out int? value)
        {
            var errors = ToInt(rawValue, out int typedValue);
            if(errors != null)
            {
                value = null;
            }
            else
            {
                value = typedValue;
            }
            return errors;
        }

        public static string ToFloat(string rawValue, out float value)
        {
            if (!float.TryParse(rawValue, out value))
            {
                return "Please enter a valid floating point number";
            }
            return null;
        }

        public static string ToNullableFloat(string rawValue, out float? value)
        {
            var errors = ToFloat(rawValue, out var typedValue);
            if (errors != null)
            {
                value = null;
            }
            else
            {
                value = typedValue;
            }
            return errors;
        }

        public static string ToDouble(string rawValue, out double value)
        {
            if (!double.TryParse(rawValue, out value))
            {
                return "Please enter a valid floating point number";
            }
            return null;
        }

        public static string ToNullableDouble(string rawValue, out double? value) 
        {
            var errors = ToDouble(rawValue, out var typedValue);
            if (errors != null)
            {
                value = null;
            }
            else
            {
                value = typedValue;
            }
            return errors;
        }

        public static string ToDateTime(string rawValue, out DateTime value)
        {
            if (!DateTime.TryParse(rawValue, out value))
            {
                return "Please enter a valid datetime";
            }
            return null;
        }

        public static string ToNullableDateTime(string rawValue, out DateTime? value)
        {
            var errors = ToDateTime(rawValue, out var typedValue);
            if (errors != null)
            {
                value = null;
            }
            else
            {
                value = typedValue;
            }
            return errors;
        }

        public static string ToDateTimeOffset(string rawValue, out DateTimeOffset value)
        {
            if (!DateTimeOffset.TryParse(rawValue, out value))
            {
                return "Please enter a valid datetime";
            }
            return null;
        }

        public static string ToNullableDateTimeOffset(string rawValue, out DateTimeOffset? value)
        {
            var errors = ToDateTime(rawValue, out var typedValue);
            if (errors != null)
            {
                value = null;
            }
            else
            {
                value = typedValue;
            }
            return errors;
        }
    }
    public class EasyConsoleInput
    {
        private EasyConsole _console;

        public EasyConsoleInput(EasyConsole console)
        {
            _console = console;
        }

        public string ReadString(string prompt, bool required = false, string defaultValue = null, Func<string, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToString, validator);
        }

        public int ReadInt(string prompt, bool required = false, int defaultValue = default, Func<int, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToInt, validator);
        }
        
        public int? ReadNullableInt(string prompt, bool required = false, int? defaultValue = default, Func<int?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToNullableInt, validator);
        }

        public float ReadFloat(string prompt, bool required = false, float defaultValue = default, Func<float, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToFloat, validator);
        }

        public float? ReadNullableFloat(string prompt, bool required = false, float? defaultValue = default, Func<float?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToNullableFloat, validator);
        }

        public double ReadDouble(string prompt, bool required = false, double defaultValue = default, Func<double, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToDouble, validator);
        }

        public double? ReadNullableDouble(string prompt, bool required = false, double? defaultValue = default, Func<double?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToNullableDouble, validator);
        }

        public DateTime ReadDateTime(string prompt, bool required = false, DateTime defaultValue = default, Func<DateTime, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToDateTime, validator);
        }

        public DateTime? ReadNullableDateTime(string prompt, bool required = false, DateTime? defaultValue = default, Func<DateTime?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToNullableDateTime, validator);
        }

        public DateTimeOffset ReadDateTimeOffset(string prompt, bool required = false, DateTimeOffset defaultValue = default, Func<DateTimeOffset, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToDateTimeOffset, validator);
        }

        public DateTimeOffset? ReadNullableDateTimeOffset(string prompt, bool required = false, DateTimeOffset? defaultValue = default, Func<DateTimeOffset?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Converters.ToNullableDateTimeOffset, validator);
        }

        //public int ReadInt(int min, int max)
        //{
        //    var value = ReadInt();

        //    while (value < min || value > max)
        //    {
        //        _console.Output.DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)", min, max);
        //        value = ReadInt();
        //    }

        //    return value;
        //}

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

        protected T RunInputLoop<T>(string prompt, bool required, T defaultValue, Converter<T> converter, Func<T, string> validator)
        {
            while (true)
            {
                DisplayPromptWithDefaultValue(prompt, defaultValue);
                var rawValue = _console.ReadLine();
                if (string.IsNullOrWhiteSpace(rawValue))
                {
                    if (!required)
                    {
                        return defaultValue;
                    }
                    else
                    {
                        continue;
                    }
                }
                var error = converter(rawValue, out var value);
                if(error != null)
                {
                    _console.WriteLine(error);
                    continue;
                }
                if (validator != null)
                {
                    error = validator(value);
                    if (error != null)
                    {
                        _console.WriteLine(error);
                        continue;
                    }
                }

                return value;
            }
        }

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
