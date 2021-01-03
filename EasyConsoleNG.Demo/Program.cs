using System;

namespace EasyConsoleNG.Demo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            new DemoMenu().Display();

            Console.Out.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
