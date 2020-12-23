using System;

namespace EasyConsoleNG.Menus
{
    public class Option<T>
    {
        public string Name { get; private set; }
        public T Value { get; private set; }
        
        public Option(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
