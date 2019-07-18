using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KB_Web.Models
{
    public class CategoryViewModels
    {
        /// <summary>
        /// Name of category
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Category badge
        /// </summary>
        public byte[] Badge { get; set; }
    }
}