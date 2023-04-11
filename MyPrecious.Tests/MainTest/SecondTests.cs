using MyPrecious.AT.Framework;
using MyPrecious.AT.Framework.CustomExceptions;
using MyPrecious.AT.Framework.Extensions;
using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Framework.Models;
using MyPrecious.AT.Framework.Models.Enums;
using MyPrecious.AT.Selenium.Helpers;
using MyPrecious.AT.Selenium.WebDriver;
using MyPrecious.Tests.Base;
using MyPrecious.Tests.BusinessActions;
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
            var user = new LoginInfo()
            {
                UserName = EnvironmentSettings.EnvironmentInfo.DefaultUserName,
                Password = EnvironmentSettings.EnvironmentInfo.DefaultPassword
            };

            TestStep($"Login as {EnvironmentSettings.EnvironmentInfo.DefaultUserName}", () =>
                new LoginActions().Login(user));
        }

        [Test]
        public void TestEnumExtensions()
        {
            var findEnumByDescription = "DEV Environment";

            TestStep("Test Enum Extensions - GetDescription", () =>
            {
                var envName = EnvironmentSettings.EnvironmentInfo.EnvironmentType.GetDescription();
                WriteLog.Info(envName);
            });

            TestStep("Test Enum Extensions - GetValueFromDescription<EnvironmentType>", () =>
            {
                var envName = findEnumByDescription.GetValueFromDescription<EnvironmentType>();
                WriteLog.Info(envName);
            });
        }

        [Test]
        public void ConditionIsMetTest()
        {
            TestStep("Test Condition Is Met - PASS", () =>
            {
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl);
                WaitUtilities.ConditionIsMet(ExpectedConditions.TitleContains("Login Page | Test Creator - TestYou"));
            });

            TestStep("Test Condition Is Met - FAIL", () =>
            {
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl);
                WaitUtilities.ConditionIsMet(ExpectedConditions.TitleContains("Login Page | Test Creator - TestYou - Mistake"));
            });
        }

        [Test]
        public void TestFatalTestingException()
        {
            TestStep("Test Fatal Exception", () =>
            {
                Driver.GetDriver().Navigate().GoToUrl(EnvironmentSettings.EnvironmentInfo.BaseUrl);

                if (!new HomePage().ProfileFirstName.IsElementPresent())
                    throw new FatalTestingException("ProfileFirstName IsElementAbsent: ");
            });
        }
    }
}