using ExpenseFunctionalTests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExpenseFunctionalTests
{
    [TestClass]
    public class SampleTestSuite : TestBase
    {
        public override void BeforeTest()
        {
        }

        [TestCategory("sample")]
        [TestMethod]
        public void SampleTest()
        {
            Assert.IsNotNull(Driver.Title);
            Assert.Fail();
        }

        public override void AfterTest()
        {
        }
    }
}
