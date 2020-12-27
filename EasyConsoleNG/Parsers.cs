using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;

namespace EasyConsoleNG
{

    public delegate ParseResult<T> Parser<T>(string rawValue);

    public static class Parsers
    {
        public static ParseResult<string> ToString(string rawValue)
        {
            return new ParseResult<string>(null, rawValue);
        }

        public static ParseResult<int> ToInt(string rawValue)
        {
            if(int.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<int>("Please enter a valid integer.");
        }

        public static ParseResult<int?> ToNullableInt(string rawValue)
        {
            if (int.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess<int?>(value);
            }

            return ParseResult.AsError<int?>("Please enter a valid integer.");
        }

        public static ParseResult<float> ToFloat(string rawValue)
        {
            if (float.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<float>("Please enter a valid floating point number.");
        }

        public static ParseResult<float?> ToNullableFloat(string rawValue)
        {
            if (float.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess<float?>(value);
            }

            return ParseResult.AsError<float?>("Please enter a valid floating point number.");
        }


        public static ParseResult<double> ToDouble(string rawValue)
        {
            if (double.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<double>("Please enter a valid floating point number.");
        }

        public static ParseResult<double?> ToNullableDouble(string rawValue)
        {
            if (double.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess<double?>(value);
            }

            return ParseResult.AsError<double?>("Please enter a valid floating point number.");
        }

        public static ParseResult<DateTime> ToDateTime(string rawValue)
        {
            if (DateTime.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<DateTime>("Please enter a valid datetime.");
        }

        public static ParseResult<DateTime?> ToNullableDateTime(string rawValue)
        {
            if (DateTime.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess<DateTime?>(value);
            }
            return ParseResult.AsError<DateTime?>("Please enter a valid datetime.");
        }

        public static ParseResult<DateTimeOffset> ToDateTimeOffset(string rawValue)
        {
            if (DateTimeOffset.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<DateTimeOffset>("Please enter a valid datetime.");
        }

        public static ParseResult<DateTimeOffset?> ToNullableDateTimeOffset(string rawValue)
        {
            if (DateTimeOffset.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess<DateTimeOffset?>(value);
            }
            return ParseResult.AsError<DateTimeOffset?>("Please enter a valid datetime.");
        }

        public static ParseResult<Uri> ToUri(string rawValue, UriKind uriKind)
        {
            if (!Uri.IsWellFormedUriString(rawValue, uriKind))
            {
                if (uriKind == UriKind.Absolute)
                {
                    return ParseResult.AsError<Uri>("Please enter an absolute URL.");
                }
                else if (uriKind == UriKind.Relative)
                {
                    return ParseResult.AsError<Uri>("Please enter a relative URL.");
                }
                else
                {
                    return ParseResult.AsError<Uri>("Please enter a valid URL.");
                }
            }

            return ParseResult.AsSuccess(new Uri(rawValue));
        }

        internal static ParseResult<MailAddress> ToEmail(string rawValue)
        {
            rawValue = rawValue.Trim();

            try { 
                var value = new MailAddress(rawValue);
                return ParseResult.AsSuccess(value);
            }
            catch (FormatException)
            {
                return ParseResult.AsError<MailAddress>("Please enter a valid email address.");
            }
        }

        public static ParseResult<IPAddress> ToIpAddress(string rawValue)
        {
            rawValue = rawValue.Trim();

            if (IPAddress.TryParse(rawValue, out var value))
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<IPAddress>("Please enter a valid IP Address.");
        }

        public static ParseResult<IPAddress> ToIpV4Address(string rawValue)
        {
            rawValue = rawValue.Trim();

            if (IPAddress.TryParse(rawValue, out var value) && value.AddressFamily == AddressFamily.InterNetwork)
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<IPAddress>("Please enter a valid IPv4 Address.");
        }

        public static ParseResult<IPAddress> ToIpV6Address(string rawValue)
        {
            rawValue = rawValue.Trim();

            if (IPAddress.TryParse(rawValue, out var value) && value.AddressFamily == AddressFamily.InterNetworkV6)
            {
                return ParseResult.AsSuccess(value);
            }

            return ParseResult.AsError<IPAddress>("Please enter a valid IPv6 Address.");
        }

    }
}
