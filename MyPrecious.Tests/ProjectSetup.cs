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

        }

        [OneTimeTearDown]
        public void ProjectOneTimeTearDown()
        {
            Driver.KillAllDriverProcesses();
        }
    }
}