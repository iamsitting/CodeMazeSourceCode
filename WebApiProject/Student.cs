using System;
using System.Text.Json.Serialization;
namespace WebApiProject
{
    public class Student
    {
        [JsonPropertyName("FullName")]
        public string Name {get; set;}
        public int Grade {get; set;}
        public DateTime LastLoggedIn {get; set;}
        [JsonIgnore]
        public Major Major {get; set;}
        [JsonInclude]
        public bool Enrolled;
    }
    public enum Major
    {
        Arts,
        Sciences,
        Philosophy
    }
}
