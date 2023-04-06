using MyPrecious.AT.Framework;
using MyPrecious.AT.Framework.Configuration.Model;
using MyPrecious.AT.Framework.Configuration;
using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Framework.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyPrecious.Tests.Base
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    public class UiTestBase : TestBase
    {
        protected readonly string BaseUrl = ConfigurationHelper.GetConfiguration()["EnvironmentConf:BaseUrl"];

        [SetUp]
        public void Setup()
        {
            Logger.InitNewLogger(TestContext.CurrentContext.Test.FullName); 
            var abc = ConfigurationHelper.GetConfiguration()["EnviromentConf:BaseUrl"];
            var abc2 = ConfigurationHelper.GetBindConfiguration<DriverInfo>(configName: "selsettings.json", section: "DriverConfiguration");
        }

        [TearDown]
        public void TearDown()
        {
            var browserLogs = Driver.GetDriver().Manage().Logs.GetLog(LogType.Browser);
            var performanceLogs = Driver.GetDriver().Manage().Logs.GetLog(LogType.Performance);

            Driver.QuiteDriver();
        }
    }
}