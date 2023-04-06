using MyPrecious.AT.Framework.Logger;
using MyPrecious.AT.Framework.WebDriver;
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
            Logger.InitNewLogger(nameof(ProjectSetUp));
        }

        [OneTimeTearDown]
        public void ProjectOneTimeTearDown()
        {
            Driver.KillAllDriverProcesses(DriverSettings.DriverInfo.DriverType);
        }
    }
}