using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseP3.Models
{
    public class Semester
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Please enter facility Name.")]
        //[Display(Name = "Name")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Please enter facility Time.")]
        //[Display(Name = "Time")]
        public string Time { get; set; }
        public int Status { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public Semester()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Status = 1;
        }
    }
}