using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseP3.Areas.Admin.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Description{ get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public virtual Category Category { get; set; }
        public string CategoryId { get; set; }
        public CousreStatus Status { get; set; }
        public enum CousreStatus
        {
            Active = 1,
            Deactive = 0,
            Delete = -1
        }
    }
}