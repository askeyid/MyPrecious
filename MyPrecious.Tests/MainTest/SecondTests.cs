using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Framework.WebDriver;
using MyPrecious.Tests.Base;
using NUnit.Framework;

namespace MyPrecious.Tests.MainTests
{
    [TestFixture]
    public class SecondTests : UiTestBase
    {
        [Test]
        public void Test01()
        {
            Logger.Info($"Test02");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test02()
        {
            Logger.Info($"Test02");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test03()
        {
            Logger.Info($"Test02");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }

        [Test]
        public void Test04()
        {
            Logger.Info($"Test02");
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }
    }
}