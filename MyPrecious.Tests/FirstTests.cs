using MyPrecious.AT.Framework;
using MyPrecious.AT.Framework.WebDriver;
using NUnit.Framework;

namespace MyPrecious.Tests
{
    [TestFixture]
    public class FirstTests : TestBase
    {
        [Test] 
        public void Test01()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }

        [Test]
        public void Test02()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }

        [Test]
        public void Test03()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }

        [Test]
        public void Test04()
        {
            Driver.GetDriver().Navigate().GoToUrl("https://www.bing.com/s");
        }
    }
}
