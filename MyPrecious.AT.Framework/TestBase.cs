using MyPrecious.AT.Framework.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MyPrecious.AT.Framework
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {

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