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
    public class SingleResourceData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }
    }
    public class ResourceData
    {
        public SingleResourceData data { get; set; }
    }
    public class ListResourceData
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<SingleResourceData> data { get; set; }
    }
    public class CreateResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public int id { get; set; }
        public string createdAt { get; set; }
    }
    public class CreateBodyObjects
    {
        public string name { get; set; }
        public string job { get; set; }
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
