using KB_DAL;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KB_Web.Models
{
    public class ArticleViewModels
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Title of Article
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Date of Publishing
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public System.DateTime PublishDate { get; set; }
        /// <summary>
        /// Hastag
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Article Note
        /// </summary>
        [Required]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
        /// <summary>
        /// Article attachments
        /// </summary>
        public byte[] Attachment { get; set; }

        // one-too-many relationship
        public int Category_Id { get; set; }
        [Display(Name = "Submitted By")]
        public virtual Category Category { get; set; }
    }
}