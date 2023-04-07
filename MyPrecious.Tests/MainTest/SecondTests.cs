using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Selenium.WebDriver;
using MyPrecious.Tests.Base;
using MyPrecious.Tests.PageObjects;
using NUnit.Framework;

namespace MyPrecious.Tests.MainTests
{
    [TestFixture]
    public class SecondTests : UiTestBase
    {
        [Test]
        public void SignUpTest()
        {
            var loginPage = new LoginPage();

            TestStep($"Open Url '{EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentInfo.BaseUrl));

            TestStep($"Login as {EnvironmentInfo.DefaultUserName}", () =>
                    loginPage.Login(new LoginInfo() { UserName = EnvironmentInfo.DefaultUserName, Password = EnvironmentInfo.DefaultPassword }));
        }
    }
}