using AutoMapper;
using KB_BAL.DTO_Model;
using KB_BAL.Interfaces;
using KB_DAL;
using KB_DAL.Interfaces;
using System.Collections.Generic;

namespace KB_BAL.Services
{
    public class PostService : IPostService
    {
        private IArticleRepository articleRepository;
        private ICategoryRepository categoryRepository;

        public PostService(
            IArticleRepository articleRepository,
            ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }

        public void CreateCategoryDTO(DTOCategory dtoaddcategory)
        {
            categoryRepository.CreateCategory(new Category
            {
                Id = dtoaddcategory.Id,
                Name = dtoaddcategory.Name,
                Badge = dtoaddcategory.Badge
            }
                );
        }
        public void DeleteCategoryDTO(int categoryid)
        {
            categoryRepository.DeleteCategory(categoryid);
        }
        public void CreateArticleDTO (DTOArticle dtoaddarticle)
        {
            articleRepository.CreateArticle(new Article
            {
                Id = dtoaddarticle.Id,
                Title = dtoaddarticle.Title,
                Category_Id = dtoaddarticle.Category_Id,
                PublishDate = dtoaddarticle.PublishDate,
                Tag = dtoaddarticle.Tag,
                Note = dtoaddarticle.Note,
                Attachment = dtoaddarticle.Attachment
            }
                );
        }
        public void EditArticleDTO(DTOArticle dtoeditarticle)
        {
            articleRepository.EditArticle(new Article
            {
                Id = dtoeditarticle.Id,
                Title = dtoeditarticle.Title,
                Category_Id = dtoeditarticle.Category_Id,
                PublishDate = dtoeditarticle.PublishDate,
                Tag = dtoeditarticle.Tag,
                Note = dtoeditarticle.Note,
                Attachment = dtoeditarticle.Attachment
            }
                );
        }
        public void DeleteArticleDTO(int dtodelarticle)
        {
            articleRepository.DeleteArticle(dtodelarticle);
        }

        public IEnumerable<DTOArticle> GetArticles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, DTOArticle>()).CreateMapper();
            var articles = mapper.Map<IEnumerable<Article>, List<DTOArticle>>(articleRepository.Articles);
            return articles;
        }

        public IEnumerable<DTOCategory> GetCategories ()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, DTOCategory>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<Category>, List<DTOCategory>>(categoryRepository.Categories);
            return categories;
        }

        public IEnumerable<DTOArticle> GetArticlesWithCategoryName()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Article, DTOArticle>()).CreateMapper();
            var articlesWithCategoryName = mapper.Map<IEnumerable<Article>, List<DTOArticle>>(articleRepository.ArticlesWithCategoryName());
            return articlesWithCategoryName;
        }
    }
}