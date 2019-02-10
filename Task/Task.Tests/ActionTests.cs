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
        public void Exchange_0_and_0_0returned()
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


    }
}