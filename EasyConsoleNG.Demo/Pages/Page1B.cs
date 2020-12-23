﻿using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    internal class Page1B : Page
    {
        public Page1B(Program program)
            : base("Page 1B", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("Hello from Page 1B");

            Input.ReadString("Press [Enter] to navigate home");
            Program.NavigateHome();
        }
    }
}
