using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsoleNG
{

    public static class BoolOptions
    {
        public static IBoolOption TrueFalse { get; } = new BoolOption("True", "False");
        public static IBoolOption YesNo { get; } = new BoolOption("Yes", "No");
        public static IBoolOption EnabledDisabled { get; } = new BoolOption("Enabled", "Disabled");
        public static IBoolOption OnOff { get; } = new BoolOption("On", "Off");

        public static IBoolOption All { get; } = new BoolOption(
            new[] { "True", "Yes", "Enabled", "On", "1" },
            new[] { "False", "No", "Disabled", "Off", "0" }
        );
    }
}
