using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Selenium.Helpers;
using MyPrecious.AT.Selenium.WebElement.BaseElements.Buttons;
using MyPrecious.AT.Selenium.WebElement.BaseElements;
using OpenQA.Selenium;

namespace MyPrecious.Tests.PageObjects
{
    public class LoginPage
    {
        public InputElement UserLogin => new InputElement(By.Id("ctl00_CPHContainer_txtUserLogin"))
        { ExpectedTitle = "Email Address / Login Id:" };

        public InputElement Password => new InputElement(By.Id("ctl00_CPHContainer_txtPassword"))
        { ExpectedTitle = "Password :" };

        public AcceptButton BtnLogin => new AcceptButton(By.CssSelector("#ctl00_CPHContainer_btnLoginn"))
        { ButtonText = "Login" };


        #region POM Methods

        public void Login(LoginInfo info)
        {
            WaitUtilities.PageLoadIsComplete();

            UserLogin.SetValue(info.UserName);
            Password.SetValue(info.Password);
            BtnLogin.Click();

            WaitUtilities.WaitUntil(x => BtnLogin.IsElementAbsent(), message: "Login Failed, BtnLogin do not disappear");
        }
        #endregion
    }
}
