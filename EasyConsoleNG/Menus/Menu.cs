using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConsoleNG.Menus
{
    public class Menu<T>
    {
        private readonly EasyConsole _console;

        private List<Option<T>> Options { get; set; };

        public Menu(EasyConsole console = null, IEnumerable<Option<T>> options = null)
        {
            _console = console ?? EasyConsole.Instance;

            if(options != null)
            {
                Options = options.ToList();
            }
            else
            {
                Options = new List<Option<T>>();
            }
        }

        public T Display()
        {
            while (true) 
            {
                for (var i = 0; i < Options.Count; i++)
                {
                    _console.Output.WriteLine("{0}. {1}", i + 1, Options[i].Name);
                }
                var choice = _console.Input.ReadInt("Choose an option:", min: 1, max: Options.Count, defaultValue: 1);

                var idx = choice - 1;
                if (idx < 0 || idx > Options.Count)
                {
                    _console.Output.WriteLine($"Invalid option.");

                    continue;
                }

                return Options[choice - 1].Value;
            }
        }

        public Menu<T> Add(string option, T value)
        {
            return Add(new Option<T>(option, value));
        }

        public Menu<T> Add(Option<T> option)
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
