using System;
using System.Threading.Tasks;

namespace EasyConsoleNG.Menus
{
    public class AsyncOption : IAsyncOption
    {
        public string Name { get; private set; }
        public Func<Task> Callback { get; private set; }

        public AsyncOption(string name, Func<Task> callback)
        {
            Name = name;
            Callback = callback;
        }

        public override string ToString()
        {
            return Name;
        }

        public Task Execute() => Callback();
    }

    public class AsyncOption<T> : IAsyncOption
    {
        public string Name { get; private set; }
        public T Value { get; private set; }
        public Func<T, Task> Callback { get; private set; }

        public AsyncOption(string name, T value, Func<T, Task> callback)
        {
            Name = name;
            Value = value;
            Callback = callback;
        }

        public override string ToString()
        {
            return Name;
        }

        public Task Execute() => Callback(Value);
    }
}
