using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsoleNG
{
    public static class Validators
    {
        public static Func<int, string> IsIntInRange(int min, int max)
        {
            return (value) =>
            {
                var checkMin = min != int.MinValue;
                var checkMax = max != int.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            };
        }

        public static Func<int?, string> IsNullableIntInRange(int min, int max)
        {
            return (value) =>
            {
                var checkMin = min != int.MinValue;
                var checkMax = max != int.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            };
        }

        public static Func<float, string> IsFloatInRange(float min, float max)
        {
            return (value) =>
            {
                var checkMin = min != float.MinValue;
                var checkMax = max != float.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            };
        }

        public static Func<float?, string> IsNullableFloatInRange(float min, float max)
        {
            return (value) =>
            {
                var checkMin = min != float.MinValue;
                var checkMax = max != float.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            };
        }

        public static Func<double, string> IsDoubleInRange(double min, double max)
        {
            return (value) =>
            {
                var checkMin = min != double.MinValue;
                var checkMax = max != double.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            };
        }

        public static Func<double?, string> IsNullableDoubleInRange(double min, double max)
        {
            return (value) =>
            {
                var checkMin = min != double.MinValue;
                var checkMax = max != double.MaxValue;

                var tooSmall = checkMin && value < min;
                var tooLarge = checkMax && value > max;

                return ValidateRange(checkMin, checkMax, min, max, tooSmall, tooLarge);
            };
        }

        private static string ValidateRange(bool checkMin, bool checkMax, double min, double max, bool tooSmall, bool tooLarge)
        {
            if (checkMin && checkMax && (tooSmall || tooLarge))
            {
                return $"Value must be between {min} and {max} (inclusive).";
            }
            else if (checkMin && tooSmall)
            {
                return $"Value must not be greater than or equal to {min}.";
            }
            else if (checkMax && tooLarge)
            {
                return $"Value must not be less than or equal to {max}.";
            }
            return null;
        }
    }
}
