﻿using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    internal class Page1A : MenuPage
    {
        public Page1A(Program program)
            : base("Page 1A", program,
                  new Option("Page 1Ai", () => program.NavigateTo<Page1Ai>()))
        {
        }
    }
}
