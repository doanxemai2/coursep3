﻿using System;
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
        public CousreStatus Status { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public enum CousreStatus
        {
            Active = 1,
            Deactive = 0,
            Delete = -1
        }
    }
}