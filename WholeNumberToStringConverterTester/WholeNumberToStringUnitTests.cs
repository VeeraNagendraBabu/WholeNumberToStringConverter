using NUnit.Framework;
using System;
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
            var result = NumberToStringConverter.ConvertNumberToReadableString("0");
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
                string s = NumberToStringConverter.ConvertNumberToReadableString(d);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }
        [Test]
        public void TestRandomNumbers()
        {
            string expectedResult = "Thirty Two";
            var result = NumberToStringConverter.ConvertNumberToReadableString("32");
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
                string s = NumberToStringConverter.ConvertNumberToReadableString(n);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }
        [Test]
        public void TestHundereds()
        {
            int i = 0;
            string[] teens = { "103", "111", "222", "233", "334", "999" };
            string[] expectedResult = { "One Hundred Three", "One Hundred Eleven", "Two Hundred Twenty Two", "Two Hundred Thirty Three", "Three Hundred Thirty Four", "Nine Hundred Ninty Nine" };
            foreach (string n in teens)
            {
                string s = NumberToStringConverter.ConvertNumberToReadableString(n);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }

        [Test]
        public void TestThousands()
        {
            int i = 0;
            string[] teens = { "1012" };
            string[] expectedResult = { "One Thousand Twelve" };
            foreach (string n in teens)
            {
                string s = NumberToStringConverter.ConvertNumberToReadableString(n);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }
        [Test]
        public void TestThousandswithMoreThan()
        {
            int i = 0;
            string[] teens = { "100812" };
            string[] expectedResult = { "One Hundred Thousand Eight Hundred Twelve" };
            foreach (string n in teens)
            {
                string s = NumberToStringConverter.ConvertNumberToReadableString(n);
                Assert.AreEqual(expectedResult[i++], s);
            }
        }
    }
}