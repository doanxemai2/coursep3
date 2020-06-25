using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using CourseP3.Areas.Admin.Models;

namespace CourseP3.Models
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int CourseId { get; set; }
        public int Point { get; set; }
        public StudentCourseStatus Status { get; set; }
        public virtual Course Course { get; set; }
        public virtual ApplicationUser Student { get; set; }

        public enum StudentCourseStatus
        {
            Completed = 1,
            Learning = 0,
            Active = 2

        }

    }
}