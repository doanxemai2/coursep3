using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseP3.Areas.Admin.Models
{
    public class FAQ
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter facility Question.")]
        [Display(Name = "Question")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Question is only allowed between 2 - 50 characters.")]
        public string Question { get; set; }
        [Required(ErrorMessage = "Please enter facility Answer.")]
        [Display(Name = "Answer")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Answer is only allowed between 2 - 50 characters.")]
        public string Answer { get; set; }
        public FAQStatus Status { get; set; }
        public enum FAQStatus
        {
            Active = 1,
            Deactive = 0,
            Delete = -1
        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DeletedAt { get; set; }

        public FAQ()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
    
            Status = FAQStatus.Active;
        }
    }
}