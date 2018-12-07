using FluentAssertions;
using NUnit.Framework;
using Refit;

namespace APITestingTest
{
    [TestFixture]
    public class UnitTest1 : Helper
    {
        [Test]
        public void TestSingleUser()
        {
            var IApi = RestService.For<Helper.Ireqres>("https://reqres.in");
            var response = IApi.getTodos().Result;

            response.Should().NotBeNull();
            response.data.id.Should().Be(2);
            response.data.first_name.Should().NotBeNullOrEmpty();
            response.data.last_name.Should().NotBeNullOrEmpty();
            response.data.avatar.Should().NotBeNullOrEmpty();
        }


        [Test]
        public void TestListUsers()
        {
            var IApi = RestService.For<Helper.ListUsers>("https://reqres.in");
            var response = IApi.GetListUsers(1).Result;

            for (int i = 1; i < 5; i++)
            {
                response = IApi.GetListUsers(i).Result;

                //write to check 200 status response
                response.Should().NotBeNull();
                response.page.Should().BeInRange(1, 12);
                response.per_page.Should().BeLessOrEqualTo(3);
                response.total.Should().Be(12);
                response.total_pages.Should().Be(4);

                if (response.data.Count > 0) 
                {
                    response.data.Should().NotBeNull();
                    response.data[0].id.Should().BeGreaterThan(0);
                    response.data[0].first_name.Should().NotBeNullOrEmpty();
                    response.data[0].last_name.Should().NotBeNullOrEmpty();
                    response.data[0].avatar.Should().NotBeNullOrEmpty();
                    response.data[0].Should().NotBeSameAs(response.data[1]);
                    response.data[0].Should().NotBeSameAs(response.data[2]);
                    response.data[1].Should().NotBeSameAs(response.data[2]);

                    response.data[1].id.Should().BeGreaterThan(0);
                    response.data[1].first_name.Should().NotBeNullOrEmpty();
                    response.data[1].last_name.Should().NotBeNullOrEmpty();
                    response.data[1].avatar.Should().NotBeNullOrEmpty();

                    response.data[2].id.Should().BeGreaterThan(0);
                    response.data[2].first_name.Should().NotBeNullOrEmpty();
                    response.data[2].last_name.Should().NotBeNullOrEmpty();
                    response.data[2].avatar.Should().NotBeNullOrEmpty();
                };
            }
        }
    }
}
