using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIADatabase.Areas.FIANCFiles.Modules
{
    public class HVI
    {
        public int HVIId { get; set; }
        public byte[] Portrait { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        public string Alias { get; set; }
        [Required(ErrorMessage = "Date of birth is required.")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public string DateofBirth { get; set; }
        [Required(ErrorMessage = "Bio is required.")]
        [AllowHtml]
        public string Bio { get; set; }
    }
}