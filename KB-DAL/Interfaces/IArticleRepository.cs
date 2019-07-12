using System.Linq;

namespace KB_DAL.Interfaces
{
    /// <summary>
    /// Article repository interface
    /// </summary>
    public interface IArticleRepository
    {
        IQueryable<Article> Articles { get; }
        void CreateArticle(Article article);
        void EditArticle(Article article);
        void DeleteArticle(int articleId);
    }
}
