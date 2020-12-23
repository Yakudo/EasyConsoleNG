using System;

namespace EasyConsoleNG.Menus
{
    public class Option : IOption
    {
        public string Name { get; private set; }
        public Action Callback { get; private set; }

        public Option(string name, Action callback)
        {
            Name = name;
            Callback = callback;
        }

        public override string ToString()
        {
            return Name;
        }

        public void Execute() => Callback();
    }

    public class Option<T> : IOption
    {
        public string Name { get; private set; }
        public T Value { get; private set; }
        public Action<T> Callback { get; private set; }

        public Option(string name, T value, Action<T> callback)
        {
            Name = name;
            Value = value;
            Callback = callback;
        }

        public override string ToString()
        {
            return Name;
        }

        public void Execute() => Callback(Value);
    }
}
