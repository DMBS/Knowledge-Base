using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KB_BAL.DTO_Model
{
    public class DTOArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime PublishDate { get; set; }
        public string Tag { get; set; }
        public string Note { get; set; }
        public byte[] Attachment { get; set; }

        //One-too-many relationship 
        public int Category_Id { get; set; }
        public virtual DTOCategory DTOCategory { get; set; }
    }
}