using NUnit.Framework;
using System.ComponentModel;
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
            var result = NumberToStringConverter.IsInputAValidOne("-1");
            Assert.IsFalse(result);
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
    }
}