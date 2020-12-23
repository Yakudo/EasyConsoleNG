using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    internal class MainPage : MenuPage
    {
        public MainPage(Program program)
            : base("Main Page", program,
                  new Option<Action>("Page 1", () => program.NavigateTo<Page1>()),
                  new Option<Action>("Page 2", () => program.NavigateTo<Page2>()),
                  new Option<Action>("Input", () => program.NavigateTo<InputPage>()),
                  new Option<Action>("Exit", () => throw new EndProgramException()))
        {
        }
    }
}
