using System;
using System.Linq;

namespace EasyConsoleNG.Menus
{

    public abstract class Page : IMenuPage
    {
        protected Menu Menu { get; }
        protected EasyConsole Console { get; }

        protected Page(Menu menu)
        {
            Menu = menu;
            Console = Menu?.Console ?? new EasyConsole();
        }

        public abstract void Display();
    }
}
