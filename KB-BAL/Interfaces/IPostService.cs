using KB_BAL.DTO_Model;
using System.Collections.Generic;

namespace KB_BAL.Interfaces
{
    public interface IPostService
    {
        IEnumerable<DTOArticle> GetArticles();
        IEnumerable<DTOArticle> GetArticlesWithCategoryName();
        IEnumerable<DTOCategory> GetCategories();
        IEnumerable<DTOArticle> GetFilterArticles(int? categoryId);
        void CreateCategoryDTO(DTOCategory dtoaddcategory);
        void DeleteCategoryDTO(int categoryId);
        void CreateArticleDTO(DTOArticle dtoaddarticle);
        void EditArticleDTO(DTOArticle dtoeditarticle);
        void DeleteArticleDTO(int dtodelarticle);
    }
}
