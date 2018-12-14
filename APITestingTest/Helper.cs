using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace APITestingTest
{
    public class Helper
    {
        public interface Ireqres
        {
            [Get("/api/users/2")]
            Task<RootObject> getTodos();
        }
        public interface ListUsers
        {
            [Get("/api/users")]
            Task<ListUsersJsonModels> GetListUsers(int page);
        }
        public interface UserNotFound
        {
            [Get("/api/users/23")]
            Task<RootObject> getTodos();
        }
        public interface SingleResource
        {
            [Get("/api/unknown")]
            Task<ResourceData> GetData(int id);
        }
        public interface ListResource
        {
            [Get("/api/unknown")]
            Task<ListResourceData> GetData(int page);
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
    }
}
