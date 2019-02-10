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

        [Test]
        public void Exchange_4_and_8_8_and_4returned()
        {
            var first = 4;
            var second = 8;
            var expectedfirst = 8;
            var expectedsecond = 4;

            var action = new Action();
            action.Exchange(ref first, ref second);

            Assert.AreEqual(expectedfirst, first);
            Assert.AreEqual(expectedsecond,second);
        }

        [Test]
        public void Exchange_n88_and_42_42_and_n88returned()
        {
            var first = -88;
            var second = 42;
            var expectedfirst = 42;
            var expectedsecond = -88;

            var action = new Action();
            action.Exchange(ref first, ref second);

            Assert.AreEqual(expectedfirst, first);
            Assert.AreEqual(expectedsecond, second);
        }

        [Test]
        public void FindMean_4_and_8_6_Expected()
        {
            var first = 4;
            var second = 8;
            var expected = 6;

            var action = new Action();
            var actual = action.FindMean(first, second);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMean_n88_and_42_n23_Expected()
        {
            var first = -88f;
            var second = 42f;
            var expected = -23f;

            var action = new Action();
            var actual = action.FindMean(first, second);

            Assert.AreEqual(expected, actual);
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