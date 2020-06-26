using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseP3.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public NewsStatus  Status { get; set; }
    public enum NewsStatus
    {
        Active = 1,
        Deactive = 0,
        Delete = -1
    }

    }
}