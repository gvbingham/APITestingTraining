using FluentAssertions;
using NUnit.Framework;
using Refit;
using System;

namespace APITestingTest
{
    [TestFixture]
    public class UnitTest1 : Helper
    {
        RegisterLoginUnsuccessfulResponse response;

        [Test]
        public void TestSingleUser()
        {            
            var response = IreqresClient.GetData().Result;

            response.Should().NotBeNull();
            response.data.id.Should().Be(2);
            response.data.first_name.Should().NotBeNullOrEmpty();
            response.data.last_name.Should().NotBeNullOrEmpty();
            response.data.avatar.Should().NotBeNullOrEmpty();
        }
        [Test, Description("Test verifies root info on all pages, and that data is not blank on pages that return data")]
        public void TestListUsers()
        {            
            var response = IListUsersClient.GetListUsers(1).Result;
            TestListUsersResponseLoop(response);
        }
        [Test]
        public void TestSingleUserNotFound()
        {
            try
            {
                var response = IUserNotFoundClient.GetData().Result;
            }
            catch (Exception ex)
            {
                ex.Message.Should().Contain("404");
            }            
        }
        [Test]
        public void TestSingleResource()
        {            
            var response = ISingleResourceClient.GetData().Result.data;

            response.Should().NotBeNull();
            response.ID.Should().BeGreaterThan(0);
            response.Name.Should().NotBeNullOrEmpty();
            response.Year.Should().BeGreaterThan(0000);
            response.Color.Should().StartWith("#");
            response.Pantone_Value.Should().NotBeNullOrEmpty();
            response.Pantone_Value.Should().HaveLength(7); 
        }
        [Test]
        public void TestSingleResourceNotFound()
        {
            try
            {
                var response = ISingleResourceNotFound.GetData().Result;
            }
            catch (Exception ex)
            {
                ex.Message.Should().Contain("404");
            }
        }
        [Test, Description("Test verifies root info on all pages, and that data is not blank on pages that return data")]
        public void TestListResource()
        {
            var response = IListResourceClient.GetData(1).Result;        
            TestListResourceResponse(response);                        
        }
        [Test]
        public void TestCreate()
        {               
            var create = new UserBodyObjects
            {
                name = "Homer",
                job = "Nucleur Safety Inspector"
            };
            var response = ICreateBodyClient.GetData(create).Result;
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
            var create = new UserBodyObjects
            {
                name = "morpheus",
                job = "zion resident"
            };
            var response = IUpdatePutUserClient.GetData(create).Result;
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
            var create = new UserBodyObjects
            {
                name = "morpheus",
                job = "zion resident"
            };
            var response = IUpdatePatchUserClient.GetData(create).Result;
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
            var create = new RegisterLoginBodyObjects
            {
                email = "IsThisTheRealLife@queen.com",
                password = "OrIsThisJustFantasy"
            };
            var response = IRegisterSuccessClient.GetData(create).Result;

            response.Should().NotBeNull();
            response.token.Should().NotBeNullOrEmpty();
            response.token.Should().HaveLength(16);
        }
        [Test]
        public void TestUnsuccessfulRegistration()
        {            
            var create = new RegisterLoginBodyObjects
            {
                email = "CaughtInALandslide@NoEscapeFromReality.com"
            };            
            try
            {
                 response = IRegisterUnsuccessfulClient.GetData(create).Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                ex.Message.Should().Contain("400");
            }                        
        }
        [Test]
        public void TestSuccessfulLogin()
        {            
            var create = new RegisterLoginBodyObjects
            {
                email = "OpenYourEyes@LookUpToTheSkyAndSee.com",
                password = "I'mJustAPoorBoyINeedNoSympathy!"
            };
            var response = ILoginSuccessfulClient.GetData(create).Result;

            response.Should().NotBeNull();
            response.token.Should().NotBeNullOrEmpty();
            response.token.Should().HaveLength(16);
        }
        [Test]
        public void TestUnsucessfulLogin()
        {
            var create = new RegisterLoginBodyObjects
            {
                email = "BecauseImEasyComeEasyGo@LittleHighLittleLow.com"
            };
            try
            {
                var response = ILoginUnSuccessfulClient.GetData(create).Result;
            }
            catch (Exception ex)
            {
                ex.Message.Should().Contain("400");
            }
        }
        [Test]
        public void TestDeleteUser()
        {
            try
            {
                var response = IDeleteUserClient.GetData().Result;
            }
            catch (Exception ex)
            {

                ex.Message.Should().Contain("204");
            }
        }
    }
}