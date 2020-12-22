using FluentAssertions;
using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_NullableInt
    {
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenReadingInt_ShouldReturnEnteredValue()
        {
            console.SetupInput("123\n");

            var value = console.Input.ReadNullableInt("Value");
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value: ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredIntWithDefaultValue_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadNullableInt("Value:", required: false, defaultValue: 123);
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value (default: 123): ");
        }

        [Test]
        public void GivenInput_WhenReadingRequiredInt_ShouldReturnEnteredValue()
        {
            console.SetupInput("\n456\n");

            var value = console.Input.ReadNullableInt("Value:", required: true, defaultValue: 123);
            value.Should().Be(456);

            console.CapturedOutput.Should().Be("Value (default: 123): Value (default: 123): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredInt_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadNullableInt("Value:", required: false, defaultValue: 123);
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value (default: 123): ");
        }
    }

}
