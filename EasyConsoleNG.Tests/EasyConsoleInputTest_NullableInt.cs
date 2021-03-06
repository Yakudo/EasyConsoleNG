﻿using FluentAssertions;
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
        public void GivenInput_WhenReading_ShouldReturnEnteredValue()
        {
            console.SetupInput("123\n");

            var value = console.Input.ReadNullableInt("Value");
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value: ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequiredWithDefaultValue_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadNullableInt("Value:", required: false, defaultValue: 123);
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value (default: 123): ");
        }

        [Test]
        public void GivenInput_WhenReadingRequired_ShouldReturnEnteredValue()
        {
            console.SetupInput("\n456\n");

            var value = console.Input.ReadNullableInt("Value:", required: true, defaultValue: 123);
            value.Should().Be(456);

            console.CapturedOutput.Should().Be("Value (default: 123): Value (default: 123): ");
        }

        [Test]
        public void GivenEmptyInput_WhenReadingNonRequired_ShouldReturnDefaultValue()
        {
            console.SetupInput("\n");

            var value = console.Input.ReadNullableInt("Value:", required: false, defaultValue: 123);
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value (default: 123): ");
        }

        [Test]
        public void GivenTooSmallValueInput_WhenReadingWithRangeContraint_ShouldReturnError()
        {
            console.SetupInput("-1\n123\n");

            var value = console.Input.ReadNullableInt("Value:", min: 0);
            value.Should().Be(123);

            console.CapturedOutput.Should().Be("Value: Value must not be greater than or equal to 0.\nValue: ");
        }

        [Test]
        public void GivenTooLargeValueInput_WhenReadingWithRangeContraint_ShouldReturnError()
        {
            console.SetupInput("123\n-1\n");

            var value = console.Input.ReadNullableInt("Value:", max: 122);
            value.Should().Be(-1);

            console.CapturedOutput.Should().Be("Value: Value must not be less than or equal to 122.\nValue: ");
        }

        [Test]
        public void GivenOutsideOfRangeInput_WhenReadingWithRangeContraint_ShouldReturnError()
        {
            console.SetupInput("123\n50");

            var value = console.Input.ReadNullableInt("Value:", min: 0, max: 100);
            value.Should().Be(50);

            console.CapturedOutput.Should().Be("Value: Value must be between 0 and 100 (inclusive).\nValue: ");
        }

        [Test]
        public void GivenOutsideOfRangeInput2_WhenReadingWithRangeContraint_ShouldReturnError()
        {
            console.SetupInput("-123\n50");

            var value = console.Input.ReadNullableInt("Value:", min: 0, max: 100);
            value.Should().Be(50);

            console.CapturedOutput.Should().Be("Value: Value must be between 0 and 100 (inclusive).\nValue: ");
        }
    }

}
