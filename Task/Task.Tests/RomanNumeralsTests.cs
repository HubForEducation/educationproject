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
        [TestCase(88, ExpectedResult="LXXXVIII")]
        [TestCase(888, ExpectedResult="DCCCLXXXVIII")]
        [TestCase(8888, ExpectedResult="MMMMMMMMDCCCLXXXVIII")] 
        public string ToRoman_Tests(int numeral)
        {
            var romanNumerals = new RomanNumerals();
            return romanNumerals.ToRoman(numeral);
        }
        [TestCase("VIII", ExpectedResult=8)]
        [TestCase("LXXXVIII", ExpectedResult=88)]
        [TestCase("DCCCLXXXVIII", ExpectedResult=888)]
        [TestCase("MMMMMMMMDCCCLXXXVIII", ExpectedResult=8888)]
        public int ToArabic_Tests(string roman)
        {
            var romanNumerals = new RomanNumerals();
            return romanNumerals.ToArabic(roman);
        }
    }
}