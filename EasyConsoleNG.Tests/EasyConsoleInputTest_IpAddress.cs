using FluentAssertions;
using NUnit.Framework;
using System.Globalization;
using System.Net;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_IpAddress
    {
        private TestEasyConsole console;

        [SetUp]
        public void SetUp()
        {
            console = new TestEasyConsole();
        }

        [Test]
        public void GivenInput_WhenReadingIpAddress_ShouldReturnEnteredValue()
        {
            console.SetupInput("1.2.3.4\n");

            var value = console.Input.ReadIpAddress("Value");
            value.Should().Be(IPAddress.Parse("1.2.3.4"));

            console.CapturedOutput.Should().Be("Value: ");
        }

        [Test]
        public void GivenInput_WhenReadingIpAddress_ShouldIgnoreWhitespaces()
        {
            console.SetupInput("  1.2.3.4  \n");

            var value = console.Input.ReadIpAddress("Value");
            value.Should().Be(IPAddress.Parse("1.2.3.4"));
        }

        [Test]
        public void GivenNoInput_WhenReadingIpAddress_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadIpAddress("Value", defaultValue: IPAddress.Parse("1.2.3.4"));
            value.Should().Be(IPAddress.Parse("1.2.3.4"));

            console.CapturedOutput.Should().Be("Value (default: 1.2.3.4): ");
        }

        [Test]
        public void GivenInvalidAddress_WhenReadingIpAddress_ShouldReturnError()
        {
            console.SetupInput("foo\n1.2.3.4\n");

            var value = console.Input.ReadIpAddress("Value");
            value.Should().Be(IPAddress.Parse("1.2.3.4"));

            console.CapturedOutput.Should().Be("Value: Please enter a valid IP Address.\nValue: ");
        }

        [Test]
        public void GivenInvalidAddress_WhenReadingIpV4Address_ShouldReturnError()
        {
            console.SetupInput("fe80::1ff:fe23:4567:890a\n\n");

            var value = console.Input.ReadIpV4Address("Value");
            value.Should().BeNull();

            console.CapturedOutput.Should().Be("Value: Please enter a valid IPv4 Address.\nValue: ");
        }

        [Test]
        public void GivenInvalidAddress_WhenReadingIpV6Address_ShouldReturnError()
        {
            console.SetupInput("1.2.3.4\n\n");

            var value = console.Input.ReadIpV6Address("Value");
            value.Should().BeNull();

            console.CapturedOutput.Should().Be("Value: Please enter a valid IPv6 Address.\nValue: ");
        }

    }

}
