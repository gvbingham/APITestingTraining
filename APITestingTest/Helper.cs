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
    }
    public class UserListParams
    {
        public string page { get; set; }
    }
    public class ResourceIDParams
    {
        public string id { get; set; }
    }
}
