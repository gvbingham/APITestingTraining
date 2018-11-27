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
    }
}
