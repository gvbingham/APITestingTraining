using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using FluentAssertions;

namespace APITestingTest
{
    public class Helper
    {
        public SingleUser IreqresClient = RestService.For<Helper.SingleUser>("https://reqres.in");
        public ListUsers IListUsersClient = RestService.For<Helper.ListUsers>("https://reqres.in");
        public UserNotFound IUserNotFoundClient = RestService.For<Helper.UserNotFound>("https://reqres.in");
        public SingleResource ISingleResourceClient = RestService.For<Helper.SingleResource>("https://reqres.in");
        public SingleResourceNotFound ISingleResourceNotFound = RestService.For<Helper.SingleResourceNotFound>("https://reqres.in");
        public ListResource IListResourceClient = RestService.For<Helper.ListResource>("https://reqres.in");
        public CreateBody ICreateBodyClient = RestService.For<Helper.CreateBody>("https://reqres.in");
        public UpdatePutUser IUpdatePutUserClient = RestService.For<Helper.UpdatePutUser>("https://reqres.in");
        public UpdatePatchUser IUpdatePatchUserClient = RestService.For<Helper.UpdatePatchUser>("https://reqres.in");
        public RegisterSuccess IRegisterSuccessClient = RestService.For<Helper.RegisterSuccess>("https://reqres.in");
        public RegisterUnsuccessful IRegisterUnsuccessfulClient = RestService.For<Helper.RegisterUnsuccessful>("https://reqres.in");
        public LoginSuccessful ILoginSuccessfulClient = RestService.For<Helper.LoginSuccessful>("https://reqres.in");
        public LoginUnsuccessful ILoginUnSuccessfulClient = RestService.For<Helper.LoginUnsuccessful>("https://reqres.in");
        public DeleteUser IDeleteUserClient = RestService.For<Helper.DeleteUser>("https://reqres.in");
        public interface SingleUser
        {
            [Get("/api/users/2")]
            Task<RootObject> GetData();
        }
        public interface ListUsers
        {
            [Get("/api/users")]
            Task<ListUsersResponse> GetListUsers(int page);
        }
        public void TestListUsersResponseLoop(ListUsersResponse response)
        {
            for (int i = 1; i < 5; i++)
            {
                response = IListUsersClient.GetListUsers(i).Result;

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
        public interface UserNotFound
        {
            [Get("/api/users/23")]
            Task<UserNotFoundResponse> GetData();
        }
        public interface SingleResource
        {
            [Get("/api/unknown")]
            Task<ResourceData> GetData();
        }
        public interface SingleResourceNotFound
        {
            [Get("/api/unknown/23")]
            Task<ResourceNotFound> GetData();
        }
        public interface ListResource
        {
            [Get("/api/unknown")]
            Task<ListResourceResponse> GetData(int page);
        }

        public void TestListResourceResponse(ListResourceResponse response)
        {
            
            for (int i = 1; i < 13; i++)
            {                
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

        public interface CreateBody
        {
            [Post("/api/users")]
            Task<CreateResponse> GetData([Body] UserBodyObjects body);
        }
        public interface UpdatePutUser
        {
            [Put("/api/users/2")]
            Task<UserResponse> GetData([Body] UserBodyObjects body);
        }
        public interface UpdatePatchUser
        {
            [Patch("/api/users/2")]
            Task<UserResponse> GetData([Body] UserBodyObjects body);
        }
        public interface RegisterSuccess
        {
            [Post("/api/register")]
            Task<RegisterLoginSuccessResponse> GetData([Body] RegisterLoginBodyObjects body);
        }
        public interface RegisterUnsuccessful
        {
            [Post("/api/register")]
            Task<RegisterLoginUnsuccessfulResponse> GetData([Body] RegisterLoginBodyObjects body);
        }
        public interface LoginSuccessful
        {
            [Post("/api/login")]
            Task<RegisterLoginSuccessResponse> GetData([Body]RegisterLoginBodyObjects body);
        }
        public interface LoginUnsuccessful
        {
            [Post("/api/login")]
            Task<RegisterLoginUnsuccessfulResponse> GetData([Body]RegisterLoginBodyObjects body);
        }
        public interface DeleteUser
        {
            [Delete("/api/users/2")]
            Task<DeleteUserResponse> GetData();
        }
    }
}
