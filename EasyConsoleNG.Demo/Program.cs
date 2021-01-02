using System;

namespace EasyConsoleNG.Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var console = new EasyConsole();
            //var value = console.Input.ReadString("Enter name");
            //console.Output.WriteLine("The value is: {0}", value);

            //var value2 = console.Input.ReadString("Enter name", required: true);
            //var value3 = console.Input.ReadString("Enter name", required: true, defaultValue: "foo");
            //console.Output.WriteLine("The value is: {0}", value);

            new DemoMenu().Run();

            Console.Out.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
