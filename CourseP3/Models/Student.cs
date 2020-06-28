using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseP3.Models
{
    public class Student
    {
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int SemesterId { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}