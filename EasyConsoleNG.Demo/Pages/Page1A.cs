using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    internal class Page1A : MenuPage
    {
        public Page1A(Program program)
            : base("Page 1A", program,
                  new Option<Action>("Page 1Ai", () => program.NavigateTo<Page1Ai>()))
        {
        }
    }
}
