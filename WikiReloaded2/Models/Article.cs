using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WikiReloaded2.Models
{
    public class Article
    {
        [Key]
        public string Id { get; set; }
        public string name { get; set; }
        public string content { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}