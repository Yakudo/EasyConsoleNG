using FluentAssertions;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Net;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Url
    {
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenReadingUrl_ShouldReturnEnteredValue()
        {
            console.SetupInput("http://example.com\n");

            var value = console.Input.ReadUrl("Value");
            value.Should().Be(new Uri("http://example.com"));

            console.CapturedOutput.Should().Be("Value: ");
        }

        [Test]
        public void GivenInput_WhenReadingUrl_ShouldIgnoreWhitespaces()
        {
            console.SetupInput("     http://example.com      \n");

            var value = console.Input.ReadUrl("Value");
            value.Should().Be(new Uri("http://example.com"));
        }

        [Test]
        public void GivenNoInput_WhenReadingUrl_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadUrl("Value", defaultValue: new Uri("http://example.com"));
            value.Should().Be(new Uri("http://example.com"));

            console.CapturedOutput.Should().Be("Value (default: http://example.com/): ");
        }

        [Test]
        public void GivenInvalidUrl_WhenReadingUrl_ShouldReturnError()
        {
            console.SetupInput("$*(&(#&@^\nhttp://example.com\n");

            var value = console.Input.ReadUrl("Value", uriKind: UriKind.RelativeOrAbsolute);
            value.Should().Be(new Uri("http://example.com"));

            console.CapturedOutput.Should().Be("Value: Please enter a valid URL.\nValue: ");
        }

        [Test]
        public void GivenRelativeUrl_WhenReadingAbsoluteUrl_ShouldReturnError()
        {
            console.SetupInput("/foo\n\n");

            var value = console.Input.ReadUrl("Value", uriKind: UriKind.Absolute);
            value.Should().BeNull();

            console.CapturedOutput.Should().Be("Value: Please enter an absolute URL.\nValue: ");
        }

        [Test]
        public void GivenAbsoluteUrl_WhenReadingRelativeUrl_ShouldReturnError()
        {
            console.SetupInput("http://example.com\n\n");

            var value = console.Input.ReadUrl("Value", uriKind: UriKind.Relative);
            value.Should().BeNull();

            console.CapturedOutput.Should().Be("Value: Please enter a relative URL.\nValue: ");
        }

    }

}
