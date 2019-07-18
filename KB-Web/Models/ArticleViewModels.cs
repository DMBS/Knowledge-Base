using System.ComponentModel.DataAnnotations;

namespace KB_Web.Models
{
    public class ArticleViewModels
    {
        /// <summary>
        /// Title of Article
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Date of Publishing
        /// </summary>
        [Required]
        public System.DateTime PublishDate { get; set; }
        /// <summary>
        /// Hastag
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// Article Note
        /// </summary>
        [Required]
        public string Note { get; set; }
        /// <summary>
        /// Article attachments
        /// </summary>
        public byte[] Attachment { get; set; }

        // one-too-many relationship
        public int Category_Id { get; set; }
        public virtual CategoryViewModels CategoryViewmodels { get; set; }
    }
}