using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using EasyConsoleNG.Menus;

namespace EasyConsoleNG.Demo.Pages
{
    public class CustomInputDemo : Page
    {
        public CustomInputDemo(Menu menu) : base(menu)
        {
        }

        public class Foo
        {
            public string Key { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return $"Foo Key={Key} Value={Value}";
            }
        }

        public override void Display()
        {
            var value = Console.Input.Read<Foo>(
                prompt: "Enter value as `<key>:<value>`", 
                required: false, 
                defaultValue: null, 
                parser: ParseFoo,
                validator: ValidateFoo);
            Console.Output.WriteLine(ConsoleColor.Green, "You entered: '{0}'", value);

            Input.ReadString("Press [Enter] to navigate back");
            Menu.Pop();
        }

        private ParseResult<Foo> ParseFoo(string rawValue)
        {
            // Convert raw input to concrete type

            var values = rawValue.Split(':');
            if(values.Length == 2)
            {
                var value = new Foo
                {
                    Key = values[0],
                    Value = values[1],
                };

                return ParseResult.AsSuccess(value);
            }
            return ParseResult.AsError<Foo>("Invalid value. Must be in `<key>:<value>` format");
        }

        private string ValidateFoo(Foo value)
        {
            //Do additioanl validation here if needed
            if(string.IsNullOrWhiteSpace(value.Value))
            {
                return "Value must not be empty";
            }

            return null;
        }
    }
}
