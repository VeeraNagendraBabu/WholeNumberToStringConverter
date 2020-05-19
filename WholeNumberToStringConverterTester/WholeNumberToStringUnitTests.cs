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
        public void TestSingleDigitNumbers()
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
        public void TestRandomNumbers()
        {
            string expectedResult = "Twenty Two";
            var result = NumberToStringConverter.ConvertNumberToString("22");
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void TestDoubleDigitNumber()
        {
            int i = 0;
            string[] teens = { "10", "11", "12", "13", "14", "15", "19" };
            string[] expectedResult = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Nineteen" };
            foreach (string n in teens)
            {
                string s = NumberToStringConverter.ConvertNumberToString(n);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }
    }
}