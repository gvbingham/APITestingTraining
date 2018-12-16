using System;
using System.Collections.Generic;
using System.Text;

namespace APITestingTest
{
    public class UserDataResponse
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }
    public class RootObject
    {
        public UserDataResponse data { get; set; }
    }
    public class UserNotFoundResponse
    {
        public string error { get; set; }
    }
    public class ListUsersResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<UserDataResponse> data { get; set; }
    }
    public class SingleResourceResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }
    }
    public class ResourceNotFound
    {
        public string error { get; set; }
    }
    public class ResourceData
    {
        public SingleResourceResponse data { get; set; }
    }
    public class ListResourceResponse
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<SingleResourceResponse> data { get; set; }
    }
    public class CreateResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public int id { get; set; }
        public string createdAt { get; set; }
    }
    public class UserBodyObjects
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class UserResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public string updatedAt { get; set; }
    }
    public class RegisterLoginBodyObjects
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class RegisterLoginSuccessResponse
    {
        public string token { get; set; }
    }
    public class RegisterLoginUnsuccessfulResponse
    {
        public string error { get; set;}
    }
    public class DeleteUserResponse
    {
        public string error { get; set; }
    }



    //public class JSONHomeWork
    //{
    //    public string Color { get; set; }
    //    public string Category { get; set; }
    //    public string Type { get; set; }
    //    public Array CodeRGBA { get; set; }
    //    public string CodeHex { get; set; }

    //}

    //public class Markers
    //{
    //    public string Name { get; set; }
    //    public List<decimal> Location { get; set; }
    //    //public Array Position { get; set; }
    //}
    //public class Root
    //{
    //    public List<Markers> Markers { get; set; }
    //}

}
