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
        public string ToRoman_Tests(int numeral)
        {
            
            //TODO Dynamic out params for Test Case.

            var romanNumerals = new RomanNumerals();
            var actual = romanNumerals.ToRoman(numeral);

            return actual;
        }
    }
}