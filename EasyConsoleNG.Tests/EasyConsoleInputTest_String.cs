using FluentAssertions;
using FluentAssertions.Primitives;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_String
    {
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenReadingString_ShouldReturnEnteredValue()
        {
            console.SetupInput("FOO\n");

            var value = console.Input.ReadString("Value");
            value.Should().Be("FOO");

            console.CapturedOutput.Should().Be("Value: ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredStringWithDefaultValue_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadString("Value:", required: false, defaultValue: "foo");
            value.Should().Be("foo");

            console.CapturedOutput.Should().Be("Value (default: foo): ");
        }

        [Test]
        public void GivenInput_WhenReadingRequiredString_ShouldReturnEnteredValue()
        {
            console.SetupInput("\nBAR\n");

            var value = console.Input.ReadString("Value:", required: true, defaultValue: "foo");
            value.Should().Be("BAR");

            console.CapturedOutput.Should().Be("Value (default: foo): Value (default: foo): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredString_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadString("Value:", required: false, defaultValue: "foo");
            value.Should().Be("foo");

            console.CapturedOutput.Should().Be("Value (default: foo): ");
        }
    }

}
