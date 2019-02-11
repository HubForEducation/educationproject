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

            var romanNumerals = new RomanNumerals();
            var actual = romanNumerals.ToRoman(numeral);

            Assert.AreEqual(expected, actual);
        }
    }
}