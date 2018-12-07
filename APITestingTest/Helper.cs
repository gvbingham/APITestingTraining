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
            //IObservable<HTTP>
        }
        public interface UserNotFound
        {
            [Get("/api/users/23")]
            Task<RootObject> getTodos();
            //Task<string>RootObject
        }
    }
    public class UserListParams
    {
        public string page { get; set; }
    }
}
