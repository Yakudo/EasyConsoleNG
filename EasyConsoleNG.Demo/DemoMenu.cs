using EasyConsoleNG.Demo.Pages;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo
{
    public static class DemoPages
    {
        public static string MainMenu = nameof(MainMenu);
        public static string InputMenu = nameof(InputMenu);
        public static string SelectDemo = nameof(SelectDemo);
        public static string CustomInputDemo = nameof(CustomInputDemo);
    }

    internal class DemoMenu : Menu
    {
        public DemoMenu() : base()
        {
            AddPage(DemoPages.MainMenu, new MainPage(this));
            AddPage(DemoPages.InputMenu, new InputMenuPage(this));
            AddPage(DemoPages.SelectDemo, new SelectDemoPage(this));
            AddPage(DemoPages.CustomInputDemo, new CustomInputDemo(this));
        }
    }
}
