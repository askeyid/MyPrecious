using MyPrecious.AT.Framework;
using MyPrecious.AT.Framework.CustomAttributes;
using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Framework.Models.Enums;
using MyPrecious.AT.Selenium.WebDriver;
using MyPrecious.Tests.Base;
using MyPrecious.Tests.BusinessActions;
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
            TestStep($"SetLoginForm as {EnvironmentSettings.EnvironmentInfo.DefaultUserName}", () =>
                new LoginActions().Login(info));
        }

        [Test]
        [Category("Smoke")]
        public void AssertLoginUi()
        {
            var loginPage = new LoginPage();

            TestStep($"Open Url '{EnvironmentSettings.EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl));

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

        [Test]
        [Category("Regression")]
        [SkipIfEnvironment(EnvironmentType.Stg)]
        public void TestSkipIfEnvironmentAttribute()
        {
            TestStep($"Open Url '{EnvironmentSettings.EnvironmentInfo.BaseUrl}'", () =>
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl));
        }
    }
}