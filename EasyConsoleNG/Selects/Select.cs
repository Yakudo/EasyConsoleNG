using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyConsoleNG.Selects
{
    public class Select<T>
    {
        private EasyConsole Console { get; set; }
        private string  Prompt { get; set; }

        private List<SelectOption<T>> Options { get; set; }
        public bool Required { get; set; }
        public T DefaultValue { get; set; }

        public Select(EasyConsole console = null, string prompt = null, IEnumerable<SelectOption<T>> options = null, bool required = false, T defaultValue = default)
        {
            Console = console ?? EasyConsole.Instance;
            Prompt = prompt ?? "Choose an option";

            if (options != null)
            {
                Options = options.ToList();
            }
            else
            {
                Options = new List<SelectOption<T>>();
            }

            Required = required;
            DefaultValue = defaultValue;
        }

        public T Display()
        {
            while (true) 
            {
                for (var i = 0; i < Options.Count; i++)
                {
                    Console.Output.WriteLine("{0}. {1}", i + 1, Options[i].Name);
                }

                int idx;

                if (Required)
                {
                    var choice = Console.Input.ReadInt(Prompt, min: 1, max: Options.Count, defaultValue: 1, required: true);
                    idx = choice - 1;
                }
                else
                {
                    var choice = Console.Input.ReadNullableInt(Prompt, min: 1, max: Options.Count, defaultValue: null, required: false);
                    if (choice == null) return DefaultValue;
                    idx = choice.Value - 1;
                }

                if (idx < 0 || idx > Options.Count)
                {
                    Console.Output.WriteLine($"Invalid option.");

                    continue;
                }

                return Options[idx].Value;
            }
        }

        public Select<T> Add(string option, T value)
        {
            return Add(new SelectOption<T>(option, value));
        }

        public Select<T> Add(SelectOption<T> option)
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
