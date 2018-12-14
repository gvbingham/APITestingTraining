using FluentAssertions;
using NUnit.Framework;
using Refit;
using System;

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
        [Test]
        public void TestSingleResource()
        {
            var IApi = RestService.For<Helper.SingleResource>("https://reqres.in");
            var response = IApi.GetData(1).Result.data;

            for (int i = 1; i < 13; i++)
            {
                response = IApi.GetData(i).Result.data;

                response.Should().NotBeNull();
                response.ID.Should().BeGreaterThan(0);
                response.Name.Should().NotBeNullOrEmpty();
                response.Year.Should().BeGreaterThan(0000);
                response.Color.Should().StartWith("#");
                response.Pantone_Value.Should().NotBeNullOrEmpty();
                response.Pantone_Value.Should().HaveLength(7);
            }  
        }
        [Test]
        public void TestListResource()
        {
            var IApi = RestService.For<Helper.ListResource>("https://reqres.in");
            var response = IApi.GetData(1).Result;
            response.Should().NotBeNull();
            for (int i = 1; i < 13; i++)
            {
                response = IApi.GetData(i).Result;

                response.Should().NotBeNull();
                response.page.Should().BeInRange(1, 12);
                response.per_page.Should().BeLessOrEqualTo(3);
                response.total.Should().Be(12);
                response.total_pages.Should().Be(4);

                if (response.data.Count > 0)
                {
                    response.data[0].ID.Should().BeGreaterThan(0);
                    response.data[0].Name.Should().NotBeNullOrEmpty();
                    response.data[0].Year.Should().BeGreaterThan(0000);
                    response.data[0].Color.Should().StartWith("#");
                    response.data[0].Pantone_Value.Should().HaveLength(7);
                    response.data[0].Should().NotBeSameAs(response.data[1]);
                    response.data[0].Should().NotBeSameAs(response.data[2]);

                    response.data[1].ID.Should().BeGreaterThan(0);
                    response.data[1].Name.Should().NotBeNullOrEmpty();
                    response.data[1].Year.Should().BeGreaterThan(0000);
                    response.data[1].Color.Should().StartWith("#");
                    response.data[1].Pantone_Value.Should().HaveLength(7);
                    response.data[1].Should().NotBeSameAs(response.data[2]);

                    response.data[2].ID.Should().BeGreaterThan(0);
                    response.data[2].Name.Should().NotBeNullOrEmpty();
                    response.data[2].Year.Should().BeGreaterThan(0000);
                    response.data[2].Color.Should().StartWith("#");
                    response.data[2].Pantone_Value.Should().HaveLength(7);
                }                
            }            
        }
        [Test]
        public void TestCreate()
        {   
            var IAPI = RestService.For<Helper.CreateBody>("https://reqres.in");
            var create = new UserBodyObjects
            {
                name = "Homer",
                job = "Nucleur Safety Inspector"
            };
            var response = IAPI.GetData(create).Result;
            var time = DateTime.Today.ToString("yyyy-MM-dd");

            response.Should().NotBeNull();
            response.createdAt.Should().NotBeNullOrEmpty();
            response.createdAt.Should().Contain(time);
            response.id.Should().BeGreaterThan(0);
            response.job.Should().Be("Nucleur Safety Inspector");
            response.name.Should().Be("Homer");
        }
        [Test]
        public void TestPutUpdateUser()
        {
            var IAPI = RestService.For<Helper.UpdatePutUser>("https://reqres.in");
            var create = new UserBodyObjects
            {
                name = "morpheus",
                job = "zion resident"
            };
            var response = IAPI.GetData(create).Result;
            var time = DateTime.Now.ToString("yyyy-MM-dd");

            response.Should().NotBeNull();
            response.updatedAt.Should().NotBeNullOrEmpty();
            response.updatedAt.Should().Contain(time);
            response.job.Should().Be("zion resident");
            response.name.Should().Be("morpheus");
        }
        [Test]
        public void TestPatchUpdateUser()
        {
            var IAPI = RestService.For<Helper.UpdatePatchUser>("https://reqres.in");
            var create = new UserBodyObjects
            {
                name = "morpheus",
                job = "zion resident"
            };
            var response = IAPI.GetData(create).Result;
            var time = DateTime.Now.ToString("yyyy-MM-dd");

            response.Should().NotBeNull();
            response.updatedAt.Should().NotBeNullOrEmpty();
            response.updatedAt.Should().Contain(time);
            response.job.Should().Be("zion resident");
            response.name.Should().Be("morpheus");
        }
        [Test]
        public void TestSuccessfulRegistration()
        {
            var IAPI = RestService.For<Helper.RegisterSuccess>("https://reqres.in");
            var create = new RegisterLoginBodyObjects
            {
                email = "IsThisTheRealLife@queen.com",
                password = "OrIsThisJustFantasy"
            };
            var response = IAPI.GetData(create).Result;

            response.Should().NotBeNull();
            response.token.Should().NotBeNullOrEmpty();
            response.token.Should().HaveLength(16);
        }
        [Test]
        public void TestUnsuccessfulRegistration()
        {
            var IAPI = RestService.For<Helper.RegisterUnsuccessful>("https://reqres.in");
            var create = new RegisterLoginBodyObjects
            {
                email = "CaughtInALandslide@NoEscapeFromReality.com"
            };
            var response = IAPI.GetData(create).Result;

            response.error.Should().Be("Missing password");
        }
        [Test]
        public void TestSuccessfulLogin()
        {
            var IAPI = RestService.For<Helper.LoginSuccessful>("https://reqres.in");
            var create = new RegisterLoginBodyObjects
            {
                email = "OpenYourEyes@LookUpToTheSkyAndSee.com",
                password = "I'mJustAPoorBoyINeedNoSympathy!"
            };
            var response = IAPI.GetData(create).Result;

            response.Should().NotBeNull();
            response.token.Should().NotBeNullOrEmpty();
            response.token.Should().HaveLength(16);
        }
    }
}
