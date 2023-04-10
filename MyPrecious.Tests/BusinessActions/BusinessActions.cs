using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Framework;
using MyPrecious.AT.Selenium.Helpers;
using MyPrecious.AT.Selenium.WebDriver;
using MyPrecious.Tests.PageObjects;

namespace MyPrecious.Tests.BusinessActions
{
    public class LoginActions
    {
        public void Login(LoginInfo info)
        {
            Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl);
            WaitUtilities.ConditionIsMet(ExpectedConditions.PageLoadIsComplete());

            var loginPage = new LoginPage();
            var homePage = new HomePage();

            loginPage.SetLoginForm(info);

            WaitUtilities.WaitUntil(x => loginPage.BtnLogin.IsElementAbsent(), message: "SetLoginForm Failed, BtnLogin do not disappear");
            WaitUtilities.WaitUntil(x => homePage.ProfileFirstName.IsElementVisible(), message: "Home Page is not opened, ProfileFirstName Is Not Visible");
        }
    }
}
