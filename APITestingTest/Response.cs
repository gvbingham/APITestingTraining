using System;
using System.Collections.Generic;
using System.Text;

namespace APITestingTest
{
    public class UserData
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class RootObject
    {
        public UserData data { get; set; }
    }

    public class ListUsersJsonModels
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserData> data { get; set; }
    }
 
    public class ListObject
    {
        public List<UserData> data { get; set; }
    }

}
