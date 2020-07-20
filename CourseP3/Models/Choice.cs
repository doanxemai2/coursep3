using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseP3.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string ChoiceContent { get; set; }
        public bool IsRight { get; set; }
    }
}