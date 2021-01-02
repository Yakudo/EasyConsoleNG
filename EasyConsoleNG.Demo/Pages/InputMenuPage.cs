using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputMenuPage : SelectPage
    {
        public InputMenuPage(Menu menu) : base(menu)
        {
            AddOption("Base input", () => Menu.Push(new InputDemoPage(Menu)));
            AddOption("String", () => Menu.Push(new InputStringDemoPage(Menu)));
            AddOption("Boolean", () => Menu.Push(new InputBoolDemoPage(Menu)));
            AddOption("Numbers (Int/Float/Double)", () => Menu.Push(new InputNumberDemoPage(Menu)));
            AddOption("Enum", () => Menu.Push(new InputEnumDemoPage(Menu)));
            AddOption("IP Address", () => Menu.Push(new InputIPAddressDemoPage(Menu)));
            AddOption("Email address", () => Menu.Push(new InputEmailDemoPage(Menu)));
            AddOption("URL", () => Menu.Push(new InputUrlDemoPage(Menu)));

            AddBackOption("Back");
        }
    }
}
