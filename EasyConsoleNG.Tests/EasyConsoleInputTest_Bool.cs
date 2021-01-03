using FluentAssertions;
using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Bool
    {
        private CultureInfo originalCulture;
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenTrueInput_WhenReadingBool_ShouldReturnTrue()
        {
            console.SetupInput("Enabled\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(true);

            console.CapturedOutput.Should().Be("Value (default: False): ");
        }

        [Test]
        public void GivenFalseInput_WhenReadingBool_ShouldReturnFalse()
        {
            console.SetupInput("Disabled\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(false);

            console.CapturedOutput.Should().Be("Value (default: False): ");
        }

        [Test]
        public void GivenTrueInput_WhenReadingBool_ShouldIgnoreCase()
        {
            console.SetupInput("ENABLED\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(true);

            console.CapturedOutput.Should().Be("Value (default: False): ");
        }

        [Test]
        public void GivenFalseInput_WhenReadingBool_ShouldIgnoreCase()
        {
            console.SetupInput("disabled\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(false);

            console.CapturedOutput.Should().Be("Value (default: False): ");
        }

        [Test]
        public void GivenTrueInput_WhenReadingBool_ShouldAllowBegining()
        {
            console.SetupInput("E\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(true);

            console.CapturedOutput.Should().Be("Value (default: False): ");
        }

        [Test]
        public void GivenFalseInput_WhenReadingBool_ShouldAllowBegining()
        {
            console.SetupInput("D\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(false);

            console.CapturedOutput.Should().Be("Value (default: False): ");
        }


        [Test]
        public void GivenInvalidInput_WhenReadingBool_ShouldRetry()
        {
            console.SetupInput("FOO\nE\n");

            var value = console.Input.ReadBool("Value");
            value.Should().Be(true);

            console.CapturedOutput.Should().Be("Value (default: False): Please enter a 'True' or 'False'.\nValue (default: False): ");
        }
    }
}
