using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace APITestingTest
{
    public class Helper
    {
        public interface IJsonPlaceholder
        {
            [Get("/todos/1")]
            Task<Response> getTodos();
        }

        public Response MakeCall()
        {
            var iJsonPlaceholder = RestService.For<IJsonPlaceholder>("https://jsonplaceholder.typicode.com");
            return iJsonPlaceholder.getTodos().Result;
        }
    }
}
