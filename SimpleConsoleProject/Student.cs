using System;
namespace SimpleConsoleProject
{
    public class Student
    {
        public string Name {get; set;}
        public int Grade {get; set;}
        public DateTime LastLoggedIn {get; set;}
        public Major Major {get; set;}
        public bool Enrolled;
    }
    public enum Major
    {
        Arts,
        Sciences,
        Philosophy
    }
}