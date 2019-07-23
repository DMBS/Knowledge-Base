using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KB_Web.Models
{
    public partial class CategoryViewModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Badge { get; set; }
    }
}