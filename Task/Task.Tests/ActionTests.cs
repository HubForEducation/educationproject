using NUnit.Framework;

namespace Task.Tests
{
    public class ActionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 0)]
        [TestCase(4, 8)]
        [TestCase(-88, 42)]
        [TestCase(88, -42)]
        public void Exchange_Tests(int first, int second)
        {
            var expectedFirst = second;
            var expectedSecond = first;

            var action = new Action();
            action.Exchange(ref first, ref second);

            Assert.AreEqual(expectedFirst, first);
            Assert.AreEqual(expectedSecond, second);
        }
    }
}