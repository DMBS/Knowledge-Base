using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_DAL.Entities
{
    public class PostEntity
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}