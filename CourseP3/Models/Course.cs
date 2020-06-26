using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CourseP3.Models;

namespace CourseP3.Areas.Admin.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Time { get; set; }
        public string Description{ get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public int? SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }
        public Course()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Status = 1;
        }
    }
}