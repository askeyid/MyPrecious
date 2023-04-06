using MyPrecious.AT.Framework.Models;
using NUnit.Framework;
using System.Collections;

namespace MyPrecious.Tests.DataSource
{
    public static class TestDataSource
    {
        public static IEnumerable LoginTestCases
        {
            get
            {
                yield return new TestCaseData(new LoginInfo() { UserName = "Admin", Password = "12345" })
                    .SetCategory("Smoke")
                    .SetName("{m}AdminTest");
                yield return new TestCaseData(new LoginInfo() { UserName = "NotAdmin", Password = "12345" })
                    .SetCategory("Regression")
                    .SetName("{m}NotAdminTest");
                yield return new TestCaseData(new LoginInfo() { UserName = "NotExistingUser", Password = "12345" })
                    .SetCategory("Regression")
                    .SetName("{m}NotExistingTest");
            }
        }
    }
}