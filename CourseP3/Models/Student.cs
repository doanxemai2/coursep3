using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseP3.Models
{
    public class Student
    {
        //[Required(ErrorMessage = "Please enter facility FullName.")]
        //[Display(Name = "FullName")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "FullName is only allowed between 2 - 50 characters.")]
        public string Fullname { get; set; }
        
        public string Phone { get; set; }
        //[Required(ErrorMessage = "Please enter facility Address.")]
        //[Display(Name = "Address")]
        public string Address { get; set; }
        //[Required(ErrorMessage = "Please enter facility Email.")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }
        public int SemesterId { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }
}