﻿using EasyConsoleNG.Selects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EasyConsoleNG
{
    public class EasyConsole
    {
        public static EasyConsole Instance { get; } = new EasyConsole();

        public TextReader InputReader { get; set; }
        public TextWriter OutputWriter { get; set; }

        public EasyConsoleInput Input { get; }
        public EasyConsoleOutput Output { get; }

        public ConsoleColor ForegroundColor
        {
            get
            {
                return Console.ForegroundColor;
            }
            set
            {
                Console.ForegroundColor = value;
            }
        }

        public EasyConsole() : this(null, null)
        {

        }

        public EasyConsole(TextReader inputReader, TextWriter outputWriter)
        {
            InputReader = inputReader ?? Console.In;
            OutputWriter = outputWriter ?? Console.Out;
            Input = new EasyConsoleInput(this);
            Output = new EasyConsoleOutput(this);
        }

        public void ResetColor() => Console.ResetColor();
        public void Clear() => Console.Clear();

        public string ReadLine() => InputReader.ReadLine();
        public Task<string> ReadLineAsync() => InputReader.ReadLineAsync();

        public void Write(string format, object[] args) => OutputWriter.Write(format, args);
        public void WriteLine(string prompt) => OutputWriter.WriteLine(prompt);
        public void WriteLine(string format, object[] args) => OutputWriter.WriteLine(format, args);
        public Task WriteLineAsync(string format, object[] args) => OutputWriter.WriteLineAsync(string.Format(format, args));

        public Select<T> Select<T>(string prompt, params SelectOption<T>[] options) => new Select<T>(this, prompt, options);

        public Select<T> Select<T>(string prompt, IEnumerable<SelectOption<T>> options, bool required = false, T defaultValue = default) => new Select<T>(this, prompt, options, required, defaultValue);
    }
}
