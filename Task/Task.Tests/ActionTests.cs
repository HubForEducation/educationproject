using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework;
using Task;
namespace Task.Tests
{
    public class ActionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(4,8)]
        [TestCase(-88, 42)]
        [TestCase(-88, 42)]
        public void Exchange_Tests(int first, int second)
        {
            var expectedFirst = second;
            var expectedSecond = first;

            var action = new Action();
            action.Exchange(ref first, ref second);

            Assert.AreEqual(expectedFirst, first);
            Assert.AreEqual(expectedSecond,second);
        }

    }

    public class RomanNumeralsTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ToRoman_8_VIII_Expected()
        {
            var numeral = 8;
            var expected = "VIII";

            var RomanNumerals = new RomanNumerals();
            var actual = RomanNumerals.ToRoman(numeral);

            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void ToRoman_18_XVIII_Expected()
        {
            var numeral = 18;
            var expected = "XVIII";

            var RomanNumerals = new RomanNumerals();
            var actual = RomanNumerals.ToRoman(numeral);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ToRoman_188_CLXXXVIII_Expected()
        {
            var numeral = 188;
            var expected = "CLXXXVIII";

            var RomanNumerals = new RomanNumerals();
            var actual = RomanNumerals.ToRoman(numeral);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ToRoman_8888_MMMMMMMMDCCCLXXXVIII_Expected()
        {
            var numeral = 8888;
            var expected = "MMMMMMMMDCCCLXXXVIII";

            var RomanNumerals = new RomanNumerals();
            var actual = RomanNumerals.ToRoman(numeral);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ToArabic_VIII_8_Expected()
        {
            var roman = "VIII";
            var expected = 8;

            var RomanNumerals = new RomanNumerals();
            var actual = RomanNumerals.ToArabic(roman);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ToArabic_LXXXVIII_88_Expected()
        {
            var roman = "LXXXVIII";
            var expected = 88;

            var RomanNumerals = new RomanNumerals();
            var actual = RomanNumerals.ToArabic(roman);

            Assert.AreEqual(expected, actual);
        }
    }
}