using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Selenium.WebDriver;
using MyPrecious.Tests.Base;
using MyPrecious.Tests.DataSource;
using MyPrecious.Tests.PageObjects;
using NUnit.Framework;

namespace MyPrecious.Tests.MainTests
{
    [TestFixture]
    public class FirstTests : UiTestBase
    {
        [Test]
        [TestCaseSource(typeof(TestDataSource), nameof(TestDataSource.LoginTestCases))]
        public void LoginUser(LoginInfo info)
        {
            var loginPage = new LoginPage();

            TestStep($"Open Url '{EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentInfo.BaseUrl));

            TestStep("Init login, an d assert result", () =>
            {
                loginPage.Login(info);

                //Assert login passed or failed
            });
        }

        [Test]
        public void AssertLoginUi()
        {
            var loginPage = new LoginPage();

            TestStep($"Open Url '{EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentInfo.BaseUrl));

            TestStep("Verify Ui login box", () =>
            {
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(loginPage.UserLogin.ExpectedTitle, loginPage.UserLogin.Title);
                    Assert.AreEqual(loginPage.Password.ExpectedTitle, loginPage.Password.Title);

                    Assert.AreEqual(loginPage.BtnLogin.ButtonText, loginPage.BtnLogin.Value);
                });
            });
        }
    }
}