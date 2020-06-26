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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }
     
        public StudentCourse()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
   
            Status = (int)StudentCourseStatus.Learning;
        }
        public enum StudentCourseStatus
        {
            Completed = 1,
            Learning = 0,
            Active = 2

        }
    }
}