using EasyConsoleNG.Selects;
using System;
using System.Linq;

namespace EasyConsoleNG.Menus
{
    public class SelectPage : Page
    {
        protected Select<Action> Select { get; set; }

        public SelectPage(Menu menu, params SelectOption<Action>[] options) : base(menu)
        {
            Select = new Select<Action>();

           foreach (var option in options)
           {
                Select.Add(option);
           }
        }

        public void AddOption(string name, Action callback)
        {
            Select.Add(new SelectOption<Action>(name, callback));
        }


        public void AddBackOption(string name)
        {
            Select.Add(new SelectOption<Action>(name, () => Menu.Pop()));
        }

        public void AddExitOption(string name)
        {
            Select.Add(new SelectOption<Action>(name, () => throw new EndMenuException()));
        }

        public override void Display()
        {
            do {
                var callback = Select.Display();
                if (callback != null)
                {
                    callback();
                    return;
                }
            } while (true);
        }
    }
}
