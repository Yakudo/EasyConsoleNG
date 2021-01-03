using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EasyConsoleNG.Menus
{
    public class Menu
    {
        public EasyConsole Console { get; }

        public string InitialPage { get; set; }
        public Stack<IMenuPage> History { get; private set; } = new Stack<IMenuPage>();
        public Dictionary<string, IMenuPage> Pages { get; set; } = new Dictionary<string, IMenuPage>();
        
        public Menu(EasyConsole console = null)
        {
            Console = console ?? new EasyConsole();
        }

        public void Push(IMenuPage page)
        {
            History.Push(page);
        }

        public void Push(string name)
        {
            var page = GetPage(name);
            Push(page);
        }

        public void Push<T>() where T : IMenuPage
        {
            var page = CreatePage<T>();
            Push(page);
        }


        public void Replace(IMenuPage page)
        {
            Pop();
            Push(page);
        }

        public void Replace(string name)
        {
            var page = GetPage(name);
            Replace(page);
        }

        public void Replace<T>() where T : IMenuPage
        {
            var page = CreatePage<T>();
            Replace(page);
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

        public void AddPage<T>(string name) where T : IMenuPage
        {
            var page = CreatePage<T>();
            AddPage(name, page);
        }

        protected IMenuPage CurrentPage
        {
            get
            {
                return (History.Any()) ? History.Peek() : null;
            }
        }

        public IMenuPage CreatePage<T>() where T : IMenuPage
        {
            return (IMenuPage)Activator.CreateInstance(typeof(T), new[] { this });
        }

        public virtual void Display()
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
