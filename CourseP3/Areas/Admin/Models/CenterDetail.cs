using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseP3.Areas.Admin.Models
{
    public class CenterDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hotline { get; set; }
        public string Description { get; set; }
        public CenterDetailStatus Status { get; set; }
        public enum CenterDetailStatus
        {
            Active = 1,
            Deactive = 0,
            Delete = -1
        }
    }
}