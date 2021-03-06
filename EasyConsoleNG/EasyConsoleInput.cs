﻿using EasyConsoleNG.Selects;
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
            return Read(prompt, required, defaultValue, Parsers.ToString, validator);
        }

        #endregion String

        #region Bool

        public bool ReadBool(string prompt, IBoolOption option = null, bool required = false, bool defaultValue = default, Func<bool, string> validator = null)
        {
            option = option ?? BoolOptions.All;
            return Read(prompt, required, defaultValue, (v) => Parsers.ToBool(v, option), validator);
        }

        #endregion Bool

        #region Int

        public int ReadInt(string prompt, Func<int, string> validator, bool required = false, int defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToInt, validator);
        }

        public int ReadInt(string prompt, bool required = false, int defaultValue = default, int min = int.MinValue, int max = int.MaxValue)
        {
            return ReadInt(prompt, Validators.IsIntInRange(min, max), required, defaultValue);
        }

        public int? ReadNullableInt(string prompt, Func<int?, string> validator, bool required = false, int? defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToNullableInt, validator);
        }

        public int? ReadNullableInt(string prompt, bool required = false, int? defaultValue = default, int min = int.MinValue, int max = int.MaxValue)
        {
            return ReadNullableInt(prompt, Validators.IsNullableIntInRange(min, max), required, defaultValue);
        }

        #endregion Int

        #region Long

        public long ReadLong(string prompt, Func<long, string> validator, bool required = false, long defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToLong, validator);
        }

        public long ReadLong(string prompt, bool required = false, long defaultValue = default, long min = long.MinValue, long max = long.MaxValue)
        {
            return ReadLong(prompt, Validators.IsLongInRange(min, max), required, defaultValue);
        }

        public long? ReadNullableLong(string prompt, Func<long?, string> validator, bool required = false, long? defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToNullableLong, validator);
        }

        public long? ReadNullableLong(string prompt, bool required = false, long? defaultValue = default, long min = long.MinValue, long max = long.MaxValue)
        {
            return ReadNullableLong(prompt, Validators.IsNullableLongInRange(min, max), required, defaultValue);
        }

        #endregion Long

        #region Float

        public float ReadFloat(string prompt, Func<float, string> validator, bool required = false, float defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToFloat, validator);
        }

        public float ReadFloat(string prompt, bool required = false, float defaultValue = default, float min = float.MinValue, float max = float.MaxValue)
        {
            return ReadFloat(prompt, Validators.IsFloatInRange(min, max), required, defaultValue);
        }

        public float? ReadNullableFloat(string prompt, Func<float?, string> validator, bool required = false, float? defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToNullableFloat, validator);
        }

        public float? ReadNullableFloat(string prompt, bool required = false, float? defaultValue = default, float min = float.MinValue, float max = float.MaxValue)
        {
            return ReadNullableFloat(prompt, Validators.IsNullableFloatInRange(min, max), required, defaultValue);
        }

        #endregion Float

        #region Double

        public double ReadDouble(string prompt, Func<double, string> validator, bool required = false, double defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToDouble, validator);
        }

        public double ReadDouble(string prompt, bool required = false, double defaultValue = default, double min = double.MinValue, double max = double.MaxValue)
        {
            return ReadDouble(prompt, Validators.IsDoubleInRange(min, max), required, defaultValue);
        }

        public double? ReadNullableDouble(string prompt, Func<double?, string> validator, bool required = false, double? defaultValue = default)
        {
            return Read(prompt, required, defaultValue, Parsers.ToNullableDouble, validator);
        }

        public double? ReadNullableDouble(string prompt, bool required = false, double? defaultValue = default, double min = double.MinValue, double max = double.MaxValue)
        {
            return ReadNullableDouble(prompt, Validators.IsNullableDoubleInRange(min, max), required, defaultValue);
        }

        #endregion Double

        #region Datetime

        public DateTime ReadDateTime(string prompt, bool required = false, DateTime defaultValue = default, Func<DateTime, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToDateTime, validator);
        }

        public DateTime? ReadNullableDateTime(string prompt, bool required = false, DateTime? defaultValue = default, Func<DateTime?, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToNullableDateTime, validator);
        }

        public DateTimeOffset ReadDateTimeOffset(string prompt, bool required = false, DateTimeOffset defaultValue = default, Func<DateTimeOffset, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToDateTimeOffset, validator);
        }

        public DateTimeOffset? ReadNullableDateTimeOffset(string prompt, bool required = false, DateTimeOffset? defaultValue = default, Func<DateTimeOffset?, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToNullableDateTimeOffset, validator);
        }

        #endregion Datetime

        #region Url

        public Uri ReadUrl(string prompt, bool required = false, UriKind uriKind = UriKind.Absolute, Uri defaultValue = default, Func<Uri, string> validator = null)
        {
            return Read(prompt, required, defaultValue, (v) => Parsers.ToUri(v, uriKind), validator);
        }

        #endregion Url

        #region IP Address

        public IPAddress ReadIpAddress(string prompt, bool required = false, IPAddress defaultValue = default, Func<IPAddress, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToIpAddress, validator);
        }

        public IPAddress ReadIpV4Address(string prompt, bool required = false, IPAddress defaultValue = default, Func<IPAddress, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToIpV4Address, validator);
        }

        public IPAddress ReadIpV6Address(string prompt, bool required = false, IPAddress defaultValue = default, Func<IPAddress, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToIpV6Address, validator);
        }

        #endregion IP Address

        #region Email

        public MailAddress ReadEmail(string prompt, bool required = false, MailAddress defaultValue = default, Func<MailAddress, string> validator = null)
        {
            return Read(prompt, required, defaultValue, Parsers.ToEmail, validator);
        }

        #endregion Email

        #region Enum

        public object ReadEnum(Type enumType, string prompt)
        {
            if (!enumType.IsEnum) throw new ArgumentException("Type must be an enumerated type");

            _console.WriteLine(prompt);
            var menu = _console.Select<object>(null);

            foreach (var value in Enum.GetValues(enumType))
            {
                menu.Add(Enum.GetName(enumType, value), (object) value);
            }
            return menu.Display();
        }

        public TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return (TEnum) ReadEnum(typeof(TEnum), prompt);
        }


        #endregion Enum

        #region Option

        public T ReadOption<T>(string prompt, IEnumerable<T> values, bool required = false, T defaultValue = default)
        {
            var options = values.Select(m => new SelectOption<T>(m.ToString(), m));
            return ReadOption<T>(prompt, options, required, defaultValue);
        }

        public T ReadOption<T>(string prompt, params T[] values) => ReadOption<T>(prompt, (IEnumerable<T>)values);

        public T ReadOption<T>(string prompt, IEnumerable<SelectOption<T>> options, bool required = false, T defaultValue = default)
        {
            _console.WriteLine(prompt);
            var menu = _console.Select(null, options, required, defaultValue);
            return menu.Display();
        }

        public T ReadOption<T>(string prompt, params SelectOption<T>[] options) => ReadOption<T>(prompt, (IEnumerable<SelectOption<T>>)options);

        #endregion Option

        #region Utils

        public T Read<T>(string prompt, bool required, T defaultValue, Parser<T> parser, Func<T, string> validator = null)
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
                var result = parser(rawValue);
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

        #endregion Utils
    }
}
