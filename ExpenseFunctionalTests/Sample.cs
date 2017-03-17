using System;
using ExpenseFunctionalTests.Infrastructure;
using ExpenseFunctionalTests.Infrastructure.DbUtils;
using NUnit.Framework;

namespace ExpenseFunctionalTests
{
    [TestFixture]
    public class SampleTestSuite : TestBase
    {
        [SetUp]
        public override void BeforeTest()
        {
            DatabaseAction.PopulateTrashboxDatabase();
        }

        [Test]
        public void SampleTest()
        {

        }

        [TearDown]
        public override void AfterTest()
        {
            DatabaseAction.CleanUpTrashboxDatabase();
        }
    }
}
