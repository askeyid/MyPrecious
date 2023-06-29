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
                yield return new TestCaseData(new LoginInfo() { UserName = "vitalii", Password = "tuqd3" })
                    .SetCategory("Smoke")
                    .SetName("{m}ViaUserNameTest");
                yield return new TestCaseData(new LoginInfo() { UserName = "vitaliikovaliuk@icloud.com", Password = "tuqd3" })
                    .SetCategory("Regression")
                    .SetName("{m}ViaEmailTest");
                yield return new TestCaseData(new LoginInfo() { UserName = "fakeuser@icloud.com", Password = "test" })
                    .SetCategory("Regression")
                    .SetName("{m}FakeUser");
            }
        }
    }
}