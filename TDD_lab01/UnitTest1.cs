using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int rc = StringCalculator.StringCalculator.Calculate("");
            Assert.Equal(0, rc);
        }

        [Theory]
        [InlineData("5", 5)]
        [InlineData("25", 25)]
        [InlineData("0", 0)]
        public void SingleNumberReturnsTheValue(string s, int expected)
        {
            int rc = StringCalculator.StringCalculator.Calculate(s);
            Assert.Equal(rc, expected);
        }

        [Theory]
        [InlineData("5, 10, 15", 30)]
        public void CommaSeparatedListReturnsSum(string s, int expected)
        {
            int rc = StringCalculator.StringCalculator.Calculate(s);
            Assert.Equal(rc, expected);
        }

        [Theory]
        [InlineData("5\n10", 15)]
        [InlineData("5, 6\n10", 21)]
        public void NewLineSeparatedNumbersReturnsSum(string s, int expected)
        {
            int rc = StringCalculator.StringCalculator.Calculate(s);
            Assert.Equal(rc, expected);
        }

        [Fact]
        public void NegativeValuesTriggerException()
        {
            _ = Assert.Throws<ArgumentException>(
                () => StringCalculator.StringCalculator.Calculate("-5, 20"));
        }

        [Theory]
        [InlineData("1000, 1", 1001)]
        public void NumbersGreaterThan1000AreIgnored(string s, int exp)
        {
            int rc = StringCalculator.StringCalculator.Calculate(s);
            Assert.Equal(rc, exp);
        }

        [Theory]
        [InlineData("//$\n5$6, 6\n6", 23)]
        public void NewLineContainsNewSeparator(string s, int exp)
        {
            int rc = StringCalculator.StringCalculator.Calculate(s);
            Assert.Equal(rc, exp);
        }
        
        [Theory]
        [InlineData("//[kupa]\n5kupa6,8\n9", 28)]
        public void NewStringSeparator(string s, int exp)
        {
            int rc = StringCalculator.StringCalculator.Calculate(s);
            Assert.Equal(exp, rc);
        }
    }
}
