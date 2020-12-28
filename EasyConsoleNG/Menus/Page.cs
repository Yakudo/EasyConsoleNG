using System;
using System.Linq;

namespace EasyConsoleNG.Menus
{

    public abstract class Page : IMenuPage
    {
        protected Menu Menu { get; }

        protected Page(Menu menu)
        {
            Menu = menu;
        }

        public abstract string GetTitle();

        public abstract void Display();
    }
}
