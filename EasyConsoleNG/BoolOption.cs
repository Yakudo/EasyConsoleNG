using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConsoleNG
{
    public class BoolOption : IBoolOption
    {
        public List<string> TrueValues { get; }
        public List<string> FalseValues { get; }
        private List<string> _normalizedTrueValue { get; }
        private List<string> _normalizedFalseValue { get; }

        public BoolOption(string trueValue, string falseValue) : this(new[] { trueValue }, new [] { falseValue })
        {
        }

        public BoolOption(IEnumerable<string> trueValues, IEnumerable<string> falseValues)
        {
            TrueValues = trueValues.ToList();
            FalseValues = falseValues.ToList();
            _normalizedTrueValue = trueValues.Select(m => m.ToLowerInvariant()).ToList();
            _normalizedFalseValue = falseValues.Select(m => m.ToLowerInvariant()).ToList();
        }

        public bool MatchesTrue(string value)
        {
            return _normalizedTrueValue.Any(m => m.StartsWith(value));
        }

        public bool MatchesFalse(string value)
        {
            return _normalizedFalseValue.Any(m => m.StartsWith(value));
        }

        public override string ToString()
        {
            return $"'{TrueValues.First()}' or '{FalseValues.First()}'";
        }
    }
}
