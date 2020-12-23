using System;

namespace EasyConsoleNG.Menus
{
    public abstract class MenuPage : Page
    {
        protected Menu<Action> Menu { get; set; }

        public MenuPage(string title, Program program, params Option<Action>[] options)
            : base(title, program)
        {
            Menu = new Menu<Action>();

            foreach (var option in options)
                Menu.Add(option);
        }

        public override void Display()
        {
            base.Display();

            if (Program.NavigationEnabled && !Menu.Contains("Go back"))
                Menu.Add("Go back", () => { Program.NavigateBack(); });

            Menu.Display();
        }
    }
}
