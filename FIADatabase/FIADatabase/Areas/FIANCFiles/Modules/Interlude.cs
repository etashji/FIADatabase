using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIADatabase.Areas.FIANCFiles.Modules
{
    public class Interlude
    {
        public int interludeId { get; set; }
        [Required(ErrorMessage = "Order is required.")]
        [Display(Name = "Order Number")]
        public int orderNumber { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Display(Name = "Area Map")]
        public byte[] areaMap { get; set; }
        [Display(Name = "District Map")]
        public byte[] districtMap { get; set; }
        [Display(Name = "Bureau Map")]
        public byte[] bureauMap { get; set; }
        [Display(Name = "Local Map")]
        public byte[] localMap { get; set; }
        [Required(ErrorMessage = "Briefing is required.")]
        [AllowHtml]
        public string Briefing { get; set; }
        public string Video { get; set; }
        [AllowHtml]
        [Display(Name = "After Action Report")]
        public string AAR { get; set; }
    }
}