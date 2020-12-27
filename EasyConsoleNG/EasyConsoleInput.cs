using EasyConsoleNG.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace EasyConsoleNG
{
    public class EasyConsoleInput
    {
        private EasyConsole _console;

        public EasyConsoleInput(EasyConsole console)
        {
            _console = console;
        }

        #region String

        public string ReadString(string prompt, bool required = false, string defaultValue = null, Func<string, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToString, validator);
        }

        #endregion String

        #region Int

        public int ReadInt(string prompt, Func<int, string> validator, bool required = false, int defaultValue = default)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToInt, validator);
        }

        public int ReadInt(string prompt, bool required = false, int defaultValue = default, int min = int.MinValue, int max = int.MaxValue)
        {
            return ReadInt(prompt, (value) =>
            {
                var checkMin = min != int.MinValue;
                var checkMax = max != int.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            }, required, defaultValue);
        }

        public int? ReadNullableInt(string prompt, Func<int?, string> validator, bool required = false, int? defaultValue = default)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToNullableInt, validator);
        }

        public int? ReadNullableInt(string prompt, bool required = false, int? defaultValue = default, int min = int.MinValue, int max = int.MaxValue)
        {
            return ReadNullableInt(prompt, (value) =>
            {
                var checkMin = min != int.MinValue;
                var checkMax = max != int.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            }, required, defaultValue);
        }

        #endregion Int

        #region Float

        public float ReadFloat(string prompt, Func<float, string> validator, bool required = false, float defaultValue = default)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToFloat, validator);
        }

        public float ReadFloat(string prompt, bool required = false, float defaultValue = default, float min = float.MinValue, float max = float.MaxValue)
        {
            return ReadFloat(prompt, (value) =>
            {
                var checkMin = min != float.MinValue;
                var checkMax = max != float.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            }, required, defaultValue);
        }

        public float? ReadNullableFloat(string prompt, Func<float?, string> validator, bool required = false, float? defaultValue = default)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToNullableFloat, validator);
        }

        public float? ReadNullableFloat(string prompt, bool required = false, float? defaultValue = default, float min = float.MinValue, float max = float.MaxValue)
        {
            return ReadNullableFloat(prompt, (value) =>
            {
                var checkMin = min != float.MinValue;
                var checkMax = max != float.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            }, required, defaultValue);
        }

        #endregion Float

        #region Double

        public double ReadDouble(string prompt, Func<double, string> validator, bool required = false, double defaultValue = default)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToDouble, validator);
        }

        public double ReadDouble(string prompt, bool required = false, double defaultValue = default, double min = double.MinValue, double max = double.MaxValue)
        {
            return ReadDouble(prompt, (value) =>
            {
                var checkMin = min != double.MinValue;
                var checkMax = max != double.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            }, required, defaultValue);
        }

        public double? ReadNullableDouble(string prompt, Func<double?, string> validator, bool required = false, double? defaultValue = default)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToNullableDouble, validator);
        }

        public double? ReadNullableDouble(string prompt, bool required = false, double? defaultValue = default, double min = double.MinValue, double max = double.MaxValue)
        {
            return ReadNullableDouble(prompt, (value) =>
            {
                var checkMin = min != double.MinValue;
                var checkMax = max != double.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            }, required, defaultValue);
        }

        #endregion Double

        #region Datetime

        public DateTime ReadDateTime(string prompt, bool required = false, DateTime defaultValue = default, Func<DateTime, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToDateTime, validator);
        }

        public DateTime? ReadNullableDateTime(string prompt, bool required = false, DateTime? defaultValue = default, Func<DateTime?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToNullableDateTime, validator);
        }

        public DateTimeOffset ReadDateTimeOffset(string prompt, bool required = false, DateTimeOffset defaultValue = default, Func<DateTimeOffset, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToDateTimeOffset, validator);
        }

        public DateTimeOffset? ReadNullableDateTimeOffset(string prompt, bool required = false, DateTimeOffset? defaultValue = default, Func<DateTimeOffset?, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToNullableDateTimeOffset, validator);
        }

        #endregion Datetime

        #region Url

        public Uri ReadUrl(string prompt, bool required = false, UriKind uriKind = UriKind.Absolute, Uri defaultValue = default, Func<Uri, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, (v) => Parsers.ToUri(v, uriKind), validator);
        }

        #endregion Url

        #region IP Address

        public IPAddress ReadIpAddress(string prompt, bool required = false, IPAddress defaultValue = default, Func<IPAddress, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToIpAddress, validator);
        }

        public IPAddress ReadIpV4Address(string prompt, bool required = false, IPAddress defaultValue = default, Func<IPAddress, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToIpV4Address, validator);
        }

        public IPAddress ReadIpV6Address(string prompt, bool required = false, IPAddress defaultValue = default, Func<IPAddress, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToIpV6Address, validator);
        }

        #endregion IP Address

        #region Email

        public MailAddress ReadEmail(string prompt, bool required = false, MailAddress defaultValue = default, Func<MailAddress, string> validator = null)
        {
            return RunInputLoop(prompt, required, defaultValue, Parsers.ToEmail, validator);
        }

        #endregion Email

        #region Enum

        public TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var type = typeof(TEnum);

            if (!type.IsEnum) throw new ArgumentException("TEnum must be an enumerated type");

            _console.WriteLine(prompt);
            var menu = _console.Menu<TEnum>();

            foreach (var value in Enum.GetValues(type))
            {
                menu.Add(Enum.GetName(type, value), (TEnum)value);
            }
            return menu.Display();
        }

        #endregion Enum

        #region Option

        public T ReadOption<T>(string prompt, IEnumerable<T> values, bool required = false, T defaultValue = default)
        {
            var options = values.Select(m => new Option<T>(m.ToString(), m));
            return ReadOption<T>(prompt, options, required, defaultValue);
        }

        public T ReadOption<T>(string prompt, params T[] values) => ReadOption<T>(prompt, (IEnumerable<T>)values);

        public T ReadOption<T>(string prompt, IEnumerable<Option<T>> options, bool required = false, T defaultValue = default)
        {
            var menu = _console.Menu(options, required, defaultValue);
            return menu.Display();
        }

        public T ReadOption<T>(string prompt, params Option<T>[] options) => ReadOption<T>(prompt, (IEnumerable<Option<T>>)options);

        #endregion Option

        #region Utils

        protected T RunInputLoop<T>(string prompt, bool required, T defaultValue, Parser<T> converter, Func<T, string> validator)
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
                var result = converter(rawValue);
                if (result.Error != null)
                {
                    _console.WriteLine(result.Error);
                    continue;
                }

                var value = result.Value;
                if (validator != null)
                {
                    var error = validator(value);
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

        private static string ValidateRange(bool checkMin, bool checkMax, double min, double max, bool tooSmall, bool tooLarge)
        {
            if (checkMin && checkMax && (tooSmall || tooLarge))
            {
                return $"Value must be between {min} and {max} (inclusive).";
            }
            else if (tooSmall)
            {
                return $"Value must not be greater than or equal to {min}.";
            }
            else if (tooLarge)
            {
                return $"Value must not be less than or equal to {max}.";
            }
            return null;
        }

        #endregion Utils
    }
}
