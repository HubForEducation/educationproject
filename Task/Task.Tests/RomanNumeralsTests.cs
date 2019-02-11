using NUnit.Framework;

namespace Task.Tests

{
    public class RomanNumeralsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(8, ExpectedResult="VIII")]
        [TestCase(8, ExpectedResult="VIII")]
        public string ToRoman_Tests(int numeral)
        {
            var romanNumerals = new RomanNumerals();
            return romanNumerals.ToRoman(numeral);
        }
    }
}