﻿using EasyConsoleNG.Menus;
using System;

namespace EasyConsoleNG.Demo.Pages
{
    public class MainPage : SelectPage
    {
        public MainPage(Menu menu)  : base(menu)
        {

            AddOption("Input Demo", () => Menu.Push(DemoPages.InputMenu));
            AddOption("Select Demo", () => Menu.Push(DemoPages.SelectDemo));
            AddExitOption("Exit");
        }
    }
}
