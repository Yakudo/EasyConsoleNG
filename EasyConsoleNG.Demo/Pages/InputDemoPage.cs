using System;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputDemoPage : Page
    {
        public InputDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadString("Enter a string");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            var value2 = Console.Input.ReadString("Enter a required string", required: true);
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value2);

            var value3 = Console.Input.ReadString("Enter a required string with default", defaultValue: "foo");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value3);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }

    }
}
