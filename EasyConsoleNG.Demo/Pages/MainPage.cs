using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    public class MainPage : SelectPage
    {
        public MainPage(Menu menu)  : base(menu)
            //: base(menu, "Main Page",
            //    new SelectOption<Action>("Page 1", () => program.NavigateTo<Page1>()),
            //    new Option<Action>("Page 2", () => program.NavigateTo<Page2>()),
            //    new Option<Action>("Input", () => program.NavigateTo<InputPage>()),
            //    new Option<Action>("Exit", () => throw new EndProgramException()))
        {

            AddOption("Input", () => Menu.Push(DemoPages.InputMenu));
            AddOption("Page 1", () => Menu.Push("page1"));
            AddOption("Page 1", () => Menu.Push("page1"));
            AddExitOption("Exit");
        }
    }
}
