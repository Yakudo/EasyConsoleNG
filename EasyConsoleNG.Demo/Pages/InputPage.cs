using System;

namespace EasyConsoleNG.Demo.Pages
{
    internal class InputPage : Page
    {
        public InputPage(Program program)
            : base("Input", program)
        {
        }

        public override void Display()
        {
            base.Display();

            var input = Input.ReadEnum<Fruit>("Select a fruit");
            Output.WriteLine(ConsoleColor.Green, "You selected {0}", input);

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }

    internal enum Fruit
    {
        Apple,
        Banana,
        Coconut
    }
}
