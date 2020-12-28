using System;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputStringPage : Page
    {
        private EasyConsole Console = new EasyConsole();

        public InputStringPage(Menu menu) : base(menu)
        {
        }

        public override string GetTitle() => "Input string demo";

        public override void Display()
        {
            var value = Console.Input.ReadString("Enter a string");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }

    }
}
