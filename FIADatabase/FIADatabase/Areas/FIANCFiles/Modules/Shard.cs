using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIADatabase.Areas.FIANCFiles.Modules
{
    public class Shard
    {
        public int shardId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        [AllowHtml]
        public string Content { get; set; }
    }
}