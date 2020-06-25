﻿using System;
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
        public string Name { get; set; }
        public string Time { get; set; }
    }
}