using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConsoleNG
{
    public class Menu
    {
        private IList<IOption> Options { get; set; } = new List<IOption>();

        public void Display()
        {
            for (var i = 0; i < Options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Options[i].Name);
            }
            var choice = 0;// Input.ReadInt("Choose an option:", min: 1, max: Options.Count);

            Options[choice - 1].Execute();
        }

        public Menu Add(string option, Action callback)
        {
            return Add(new Option(option, callback));
        }

        public Menu Add<T>(string option, T value, Action<T> callback)
        {
            return Add(new Option<T>(option, value, callback));
        }

        public Menu Add(IOption option)
        {
            Options.Add(option);
            return this;
        }

        public bool Contains(string option)
        {
            return Options.FirstOrDefault((op) => op.Name.Equals(option)) != null;
        }
    }
}
