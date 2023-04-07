using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Selenium.WebDriver;
using NUnit.Framework;

[assembly: LevelOfParallelism(6)]
namespace MyPrecious.Tests
{
    [SetUpFixture]
    public class ProjectSetUp
    {
        [OneTimeSetUp]
        public void ProjectOneTimeSetUp()
        {
            WriteLog.InitNewLogger(nameof(ProjectSetUp));
        }

        [OneTimeTearDown]
        public void ProjectOneTimeTearDown()
        {
            Driver.KillAllDriverProcesses(DriverSettings.DriverInfo.DriverType);
        }
    }
}