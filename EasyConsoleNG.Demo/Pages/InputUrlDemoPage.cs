using System;
using System.Net;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputUrlDemoPage : Page
    {
        public InputUrlDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadUrl("Enter an URL", defaultValue: new Uri("http://example.com"));
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            var value2 = Console.Input.ReadUrl("Enter an absolute URL", uriKind: UriKind.Absolute, defaultValue: new Uri("http://example.com"));
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value2);

            var value3 = Console.Input.ReadUrl("Enter a relative URL", uriKind: UriKind.Relative, defaultValue: new Uri("/foo"));
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value3);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }

    }
}
