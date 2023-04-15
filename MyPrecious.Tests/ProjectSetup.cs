using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Selenium.WebDriver;
using NUnit.Framework;

[assembly: LevelOfParallelism(2)]
namespace MyPrecious.Tests
{
    [SetUpFixture]
    public class ProjectSetup
    {
        [OneTimeSetUp]
        public void ProjectOneTimeSetUp()
        {
            WriteLog.InitNewLogger(nameof(ProjectSetup));
        }

        [OneTimeTearDown]
        public void ProjectOneTimeTearDown()
        {
            Driver.KillAllDriverProcesses(DriverSettings.DriverInfo.DriverType);
        }
    }
}