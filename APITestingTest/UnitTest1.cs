using FluentAssertions;
using NUnit.Framework;
using Refit;

namespace APITestingTest
{
    [TestFixture]
    public class UnitTest1 : Helper
    {
        [Test]
        public void TestMethod1()
        {
            var IApi = RestService.For<Helper.Ireqres>("https://reqres.in");
            var response = IApi.getTodos().Result;
            response.Should().NotBeNull();
        }
    }
}
