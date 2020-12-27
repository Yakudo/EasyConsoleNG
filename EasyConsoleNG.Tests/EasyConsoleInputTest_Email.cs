using FluentAssertions;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Email
    {
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenReadingEmail_ShouldReturnEnteredValue()
        {
            console.SetupInput("test@example.com\n");

            var value = console.Input.ReadEmail("Value");
            value.Should().Be(new MailAddress("test@example.com"));

            console.CapturedOutput.Should().Be("Value: ");
        }

        [Test]
        public void GivenInput_WhenReadingEmail_ShouldIgnoreWhitespaces()
        {
            console.SetupInput("     test@example.com      \n");

            var value = console.Input.ReadEmail("Value");
            value.Should().Be(new MailAddress("test@example.com"));
        }

        [Test]
        public void GivenNoInput_WhenReadingEmail_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadEmail("Value", defaultValue: new MailAddress("test@example.com"));
            value.Should().Be(new MailAddress("test@example.com"));

            console.CapturedOutput.Should().Be("Value (default: test@example.com): ");
        }

        [Test]
        public void GivenInvalidEmail_WhenReadingEmail_ShouldReturnError()
        {
            console.SetupInput("$*(&(#&@^\ntest@example.com\n");

            var value = console.Input.ReadEmail("Value");
            value.Should().Be(new MailAddress("test@example.com"));

            console.CapturedOutput.Should().Be("Value: Please enter a valid email address.\nValue: ");
        }
    }
}
