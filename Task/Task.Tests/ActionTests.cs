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
            int first = 4;
            int second = 8;
            int expectedfirst = 8;
            int expectedsecond = 4;

            Action action = new Action();
            action.Exchange(ref first, ref second);

            Assert.AreEqual(expectedfirst, first);
            Assert.AreEqual(expectedsecond,second);
        }

        [Test]
        public void Exchange_n88_and_42_42_and_n88returned()
        {
            int first = -88;
            int second = 42;
            int expectedfirst = 42;
            int expectedsecond = -88;

            Action action = new Action();
            action.Exchange(ref first, ref second);

            Assert.AreEqual(expectedfirst, first);
            Assert.AreEqual(expectedsecond, second);
        }

        [Test]
        public void FindMean_4_and_8_6_Expected()
        {
            int first = 4;
            int second = 8;
            int expected = 6;

            Action action = new Action();
            float actual = action.FindMean(first, second);

            Assert.AreEqual(expected, actual);
        }
    }
}