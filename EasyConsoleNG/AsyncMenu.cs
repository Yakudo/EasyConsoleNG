using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyConsoleNG
{
    public class AsyncMenu
    {
        private IList<IAsyncOption> Options { get; set; } = new List<IAsyncOption>();

        public async Task Display()
        {
            for (var i = 0; i < Options.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, Options[i].Name);
            }
            var choice = Input.ReadInt("Choose an option:", min: 1, max: Options.Count);

            await Options[choice - 1].Execute();
        }

        public AsyncMenu Add(string option, Func<Task> callback)
        {
            return Add(new AsyncOption(option, callback));
        }

        public AsyncMenu Add<T>(string option, T value, Func<T, Task> callback)
        {
            return Add(new AsyncOption<T>(option, value, callback));
        }

        public AsyncMenu Add(IAsyncOption option)
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
