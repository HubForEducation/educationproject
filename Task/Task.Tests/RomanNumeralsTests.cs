using NUnit.Framework;

namespace Task.Tests

{
    public class RomanNumeralsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(8)]
        public void ToRoman_Tests(int numeral)
        {
            var expected = "VIII";
            //TODO Dynamic out params for Test Case.

            var romanNumerals = new RomanNumerals();
            var actual = romanNumerals.ToRoman(numeral);

            Assert.AreEqual(expected, actual);
        }
    }
}