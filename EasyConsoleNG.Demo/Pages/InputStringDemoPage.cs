using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputStringDemoPage : Page
    {
        public InputStringDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadString("Enter a string");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }
    }
}
