using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Linq;
using WholeNumberToStringConverter;

namespace WholeNumberToStringConverterTester
{
    [TestFixture]
    public class WholeNumberToStringUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfZeroIsWholeNumberOrNot()
        {
            var result = NumberToStringConverter.IsInputAValidOne("0");
            Assert.IsTrue(result);
        }
        [Test]
        public void CheckIfANegativeNumberIsWholeNumberOrNot()
        {
            Assert.Throws<ArgumentException>(() => NumberToStringConverter.IsInputAValidOne("0.23"));
        }
        [Test]
        public void CheckIfaRandomNumberIsWholeNumberOrNot()
        {
            var result = NumberToStringConverter.IsInputAValidOne("999999999999999999");
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfTheSpellerRespondsRightForLowestWholeNumber()
        {
            string expectedResult = "Zero";
            var result = NumberToStringConverter.ConvertNumberToString("0");
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void TestDigits()
        {
            int i = 0;
            string[] digits = Enumerable.Range(0, 9).Select(o => o.ToString()).ToArray();
            string[] expectedResult = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            foreach (string d in digits)
            {
                string s = NumberToStringConverter.ConvertNumberToString(d);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }
        [Test]
        public void TestDoubleDigitis()
        {
            string expectedResult = "Twenty Two";
            var result = NumberToStringConverter.ConvertNumberToString("22");
            Assert.AreEqual(expectedResult, result);
        }
    }
}