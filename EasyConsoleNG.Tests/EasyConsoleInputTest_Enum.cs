using FluentAssertions;
using NUnit.Framework;
using System.Globalization;
using System.Threading;

namespace EasyConsoleNG.Tests
{
    [TestFixture]
    public class EasyConsoleInputTest_Enum
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
        public void GivenInput_WhenReadingInt_ShouldReturnEnteredValue()
        {
            console.SetupInput("2\n");

            var value = console.Input.ReadEnum<Fruit>("Value");
            value.Should().Be(Fruit.Banana);
        }

    }

}
