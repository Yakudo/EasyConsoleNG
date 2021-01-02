using EasyConsoleNG.Menus;
using System;
using System.Net;

namespace EasyConsoleNG.Demo.Pages
{
    public class InputIPAddressDemoPage : Page
    {
        public InputIPAddressDemoPage(Menu menu) : base(menu)
        {
        }

        public override void Display()
        {
            var value = Console.Input.ReadIpAddress("Enter an IP Address (V4 or V6)", defaultValue: IPAddress.Parse("127.0.0.1"));
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            var value2 = Console.Input.ReadIpV4Address("Enter an IPv4 Address", defaultValue: IPAddress.Parse("127.0.0.1"));
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value2);

            var value3 = Console.Input.ReadIpV6Address("Enter an IPv6 Address", defaultValue: IPAddress.Parse("::1"));
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value3);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }
    }
}
