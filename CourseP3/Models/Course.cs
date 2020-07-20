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
        //[Required(ErrorMessage = "Please enter facility Name.")]
        //[Display(Name = "Name")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Name is only allowed between 2 - 50 characters.")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter facility Title.")]
        //[Display(Name = "Title")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Title is only allowed between 2 - 50 characters.")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Please enter facility Time.")]
        //[Display(Name = "Time")]
        //[StringLength(50, MinimumLength = 2, ErrorMessage = "Time is only allowed between 2 - 50 characters.")]
        public string Time { get; set; }
        public string Description{ get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public int? SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
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