using EasyConsoleNG.Menus;
using System;

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
            Console.ReadLine();
            Console.Clear();

            var value2 = Console.Input.ReadString("Enter a string", required: true);
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value2);
            Console.ReadLine();
            Console.Clear();

            var value3 = Console.Input.ReadString("Enter a string", defaultValue: "foo");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value3);
            Console.ReadLine();
            Console.Clear();

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }
    }
}
