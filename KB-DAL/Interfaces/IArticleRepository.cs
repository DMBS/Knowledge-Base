using System.Collections.Generic;
using System.Linq;

namespace KB_DAL.Interfaces
{
    /// <summary>
    /// Article repository interface
    /// </summary>
    public interface IArticleRepository
    {
        IQueryable<Article> Articles { get; }
        IEnumerable<Article> ArticlesWithCategoryName();
        IEnumerable<Article> GetFilterArticles(int? categoryId);
        Article ArticleDetails(int? articleId);
        Article FindArticleById(int? articleId);
        void CreateArticle(Article article);
        void EditArticle(Article article);
        void DeleteArticle(int? articleId);
    }
}
