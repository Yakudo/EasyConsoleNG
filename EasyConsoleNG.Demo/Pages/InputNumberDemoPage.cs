using System;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputNumberDemoPage : Page
    {
        public InputNumberDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadInt("Enter an integer");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            var value2 = Console.Input.ReadInt("Enter an integer in range (0, 10) ", min: 0, max: 10);
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value2);

            var value3 = Console.Input.ReadFloat("Enter an float/double");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value3);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }

    }
}
