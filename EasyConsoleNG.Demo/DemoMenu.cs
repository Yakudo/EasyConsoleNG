using System;
using EasyConsoleNG.Demo.Pages;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo
{
    public static class DemoPages
    {
        public static string MainMenu = nameof(MainMenu);
        public static string InputMenu = nameof(InputMenu);
    }

    internal class DemoMenu : Menu
    {
        public DemoMenu() : base()
        {
            AddPage(DemoPages.MainMenu, new MainPage(this));
            AddPage(DemoPages.InputMenu, new InputMenuPage(this));
            //AddPage(new Page1(this));
            //AddPage(new Page1A(this));
            //AddPage(new Page1Ai(this));
            //AddPage(new Page1B(this));
            //AddPage(new Page2(this));
            //AddPage(new InputPage(this));

            //SetPage<MainPage>();
        }

    }
}
