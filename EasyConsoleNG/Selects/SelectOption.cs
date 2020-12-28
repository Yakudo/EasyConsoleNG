using System;

namespace EasyConsoleNG.Selects
{
    public class SelectOption<T>
    {
        public string Name { get; private set; }
        public T Value { get; private set; }
        
        public SelectOption(string name, T value)
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
