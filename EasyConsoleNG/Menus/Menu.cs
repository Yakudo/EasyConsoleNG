using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EasyConsoleNG.Menus
{
    public class Menu
    {
        public string InitialPage { get; set; }
        public Stack<IMenuPage> History { get; private set; } = new Stack<IMenuPage>();
        public Dictionary<string, IMenuPage> Pages { get; set; } = new Dictionary<string, IMenuPage>();

        public void Push(string name)
        {
            var page = GetPage(name);
            Push(page);
        }

        public void Push(IMenuPage page)
        {
            History.Push(page);
        }

        public void Replace(IMenuPage page)
        {
            Pop();
            Push(page);
        }

        public void Pop()
        {
            History.Pop();
        }

        public IMenuPage GetPage(string name)
        {
            if (Pages.TryGetValue(name, out var page))
            {
                return page;
            }
            return null;
        }

        public void AddPage(string name, IMenuPage page)
        {
            Pages[name] = page;
            InitialPage = InitialPage ?? name;
        }

        protected IMenuPage CurrentPage
        {
            get
            {
                return (History.Any()) ? History.Peek() : null;
            }
        }

        public virtual void Run()
        {
            History.Clear();
            var page = GetPage(InitialPage);
            Push(page);

            while(CurrentPage != null)
            {
                Console.Clear();
                try
                {
                    CurrentPage.Display();
                }
                catch (EndMenuException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Output.WriteLine(ConsoleColor.Red, e.ToString());
                }
            }
        }
    }
}
