using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseP3.Areas.Admin.Models
{
    public class CenterDetail
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter facility Name.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Phone")]
        public int Hotline { get; set; }
        public string Description { get; set; }
        public CenterDetailStatus Status { get; set; }
        public enum CenterDetailStatus
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

        public CenterDetail()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;

            Status = CenterDetailStatus.Active;
        }
    }
}