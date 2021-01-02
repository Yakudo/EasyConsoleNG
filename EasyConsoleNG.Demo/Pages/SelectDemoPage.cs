using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    public class SelectDemoPage : Page
    {
        public SelectDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadOption("Value", new[] { "A", "B", "C" }, defaultValue: "C");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }
    }
}
