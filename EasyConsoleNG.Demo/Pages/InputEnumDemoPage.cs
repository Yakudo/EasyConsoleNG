using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputEnumDemoPage : Page
    {
        public InputEnumDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadEnum<Fruit>("Select a fruit");
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            Console.Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }
    }

    public enum Fruit
    {
        Apple,
        Strawberry,
        Banana,
    }
}
