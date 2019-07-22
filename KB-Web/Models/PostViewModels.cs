using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_Web.Models
{
    // Common ViewModel include Articles and Categories
    public class PostViewModels
    {
        public ArticleViewModels Articles { get; set; }

        public CategoryViewModels Categories { get; set; }

    }
}