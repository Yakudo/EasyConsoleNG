using FluentAssertions;
using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Menu
    {
        private TestEasyConsole console;

        public enum Fruit
        {
            Apple,
            Banana,
        }

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenSelectingOption_ShouldReturnCorrectValue()
        {
            console.SetupInput("2\n");

            var value = console.Input.ReadOption("Value", "A", "B", "C");

            value.Should().Be("B");

            console.CapturedOutput.Should().Be("1. A\n2. B\n3. C\nChoose an option: ");
        }

        [Test]
        public void GivenInvalidInput_WhenSelectingOption_ShouldReturnCorrectValue()
        {
            console.SetupInput("5\n2\n");

            var value = console.Input.ReadOption("Value", "A", "B", "C");

            value.Should().Be("B");

            console.CapturedOutput.Should().Be("1. A\n2. B\n3. C\nChoose an option: Value must be between 1 and 3 (inclusive).\nChoose an option: ");
        }

        [Test]
        public void GivenNoInput_WhenSelectingOption_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadOption("Value", new[] { "A", "B", "C" }, defaultValue: "C");

            value.Should().Be("C");

            console.CapturedOutput.Should().Be("1. A\n2. B\n3. C\nChoose an option: ");

        }
    }

}
