using System;
using System.Net;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputEmailDemoPage : Page
    {
        public InputEmailDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadEmail("Enter an email address");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }

    }
}
