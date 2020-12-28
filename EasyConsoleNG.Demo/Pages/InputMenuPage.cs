using System;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputMenuPage : SelectPage
    {
        public InputMenuPage(Menu menu) : base(menu)
        //: base(menu, "Main Page",
        //    new SelectOption<Action>("Page 1", () => program.NavigateTo<Page1>()),
        //    new Option<Action>("Page 2", () => program.NavigateTo<Page2>()),
        //    new Option<Action>("Input", () => program.NavigateTo<InputPage>()),
        {

            AddOption("String", () => Menu.Push(new InputStringPage(Menu)));
            AddOption("Numbers (Int/Float/Double)", () => Menu.Push(new InputNumberPage(Menu)));
            AddBackOption("Back");
        }
    }
}
