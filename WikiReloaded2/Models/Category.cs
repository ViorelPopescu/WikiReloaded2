using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WikiReloaded2.Models
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
    }
}