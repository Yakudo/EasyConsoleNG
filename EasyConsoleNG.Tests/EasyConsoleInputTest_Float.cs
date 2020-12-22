using FluentAssertions;
using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Float
    {
        private CultureInfo originalCulture;
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();

            originalCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [TearDown]
        public void TearDown()
        {
            Thread.CurrentThread.CurrentCulture = originalCulture;
        }

        [Test]
        public void GivenInput_WhenReadingInt_ShouldReturnEnteredValue()
        {
            console.SetupInput("123.4\n");

            var value = console.Input.ReadFloat("Value");
            value.Should().Be(123.4f);

            console.CapturedOutput.Should().Be("Value (default: 0): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredIntWithDefaultValue_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadFloat("Value:", required: false, defaultValue: 123.4f);
            value.Should().Be(123.4f);

            console.CapturedOutput.Should().Be("Value (default: 123.4): ");
        }

        [Test]
        public void GivenInput_WhenReadingRequiredInt_ShouldReturnEnteredValue()
        {
            console.SetupInput("\n456\n");

            var value = console.Input.ReadFloat("Value:", required: true, defaultValue: 123.4f);
            value.Should().Be(456.0f);

            console.CapturedOutput.Should().Be("Value (default: 123.4): Value (default: 123.4): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredInt_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadFloat("Value:", required: false, defaultValue: 123.4f);
            value.Should().Be(123.4f);

            console.CapturedOutput.Should().Be("Value (default: 123.4): ");
        }
    }

}
