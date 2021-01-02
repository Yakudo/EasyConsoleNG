using FluentAssertions;
using NUnit.Framework;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Long
    {
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenReadingLong_ShouldReturnEnteredValue()
        {
            console.SetupInput("123\n");

            var value = console.Input.ReadLong("Value");
            value.Should().Be(123L);

            console.CapturedOutput.Should().Be("Value (default: 0): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredWithDefaultValue_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadLong("Value:", required: false, defaultValue: 123L);
            value.Should().Be(123L);

            console.CapturedOutput.Should().Be("Value (default: 123): ");
        }

        [Test]
        public void GivenInput_WhenReadingRequired_ShouldReturnEnteredValue()
        {
            console.SetupInput("\n456\n");

            var value = console.Input.ReadLong("Value:", required: true, defaultValue: 123L);
            value.Should().Be(456L);

            console.CapturedOutput.Should().Be("Value (default: 123): Value (default: 123): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequired_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadLong("Value:", required: false, defaultValue: 123L);
            value.Should().Be(123L);

            console.CapturedOutput.Should().Be("Value (default: 123): ");
        }

        [Test]
        public void GivenTooSmallValueInput_WhenReadingWithRangeContraLong_ShouldReturnError()
        {
            console.SetupInput("-1\n123\n");

            var value = console.Input.ReadLong("Value:", min: 0L);
            value.Should().Be(123L);

            console.CapturedOutput.Should().Be("Value (default: 0): Value must not be greater than or equal to 0.\nValue (default: 0): ");
        }

        [Test]
        public void GivenTooLargeValueInput_WhenReadingWithRangeContraLong_ShouldReturnError()
        {
            console.SetupInput("123\n-1\n");

            var value = console.Input.ReadLong("Value:", max: 122L);
            value.Should().Be(-1L);

            console.CapturedOutput.Should().Be("Value (default: 0): Value must not be less than or equal to 122.\nValue (default: 0): ");
        }

        [Test]
        public void GivenOutsideOfRangeInput_WhenReadingWithRangeContraLong_ShouldReturnError()
        {
            console.SetupInput("123\n50");

            var value = console.Input.ReadLong("Value:", min: 0L, max: 100L);
            value.Should().Be(50L);

            console.CapturedOutput.Should().Be("Value (default: 0): Value must be between 0 and 100 (inclusive).\nValue (default: 0): ");
        }
    }

}
