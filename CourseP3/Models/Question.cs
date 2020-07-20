using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CourseP3.Areas.Admin.Models;

namespace CourseP3.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public int Point { get; set; }
        public string AnswerContent { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}