using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseP3.Areas.Admin.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public FAQStatus Status { get; set; }
        public enum FAQStatus
        {
            Active = 1,
            Deactive = 0,
            Delete = -1
        }
    }
}