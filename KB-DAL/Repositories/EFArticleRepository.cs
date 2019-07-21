using KB_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace KB_DAL.Repositories
{
    /// <summary>
    /// Article repository with CRUD operation and save domain articles in Database
    /// </summary>
    public class EFArticleRepository : IArticleRepository
    {
        private KBEntities context = new KBEntities();

        public IQueryable<Article> Articles
        {
            get
            {
                return context.Articles;
            }
        }

        public IEnumerable<Article> ArticlesWithCategoryName()
        {
            var query = from art in context.Articles
                        join cat in context.Categories
                        on art.Category_Id equals cat.Id
                        select new
                        {
                            art.Id,
                            art.Category_Id,
                            art.Title,
                            art.PublishDate,
                            art.Tag,
                            art.Note,
                            cat
                        };
            var result = query.ToList()
                .Select(e => new Article
                {
                    Id = e.Id,
                    Category_Id = e.Category_Id,
                    Title = e.Title,
                    PublishDate = e.PublishDate,
                    Tag = e.Tag,
                    Note = e.Note,
                    Category = e.cat
                })
                .ToList();

            return result;
        }

        /// <summary>
        /// Create article with save in DB
        /// </summary>
        /// <param name="article"></param>
        public void CreateArticle (Article article)
        {
            if (article == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Articles.Add(article);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// Edit article with save in DB
        /// </summary>
        /// <param name="article"></param>
        public void EditArticle (Article article)
        {
            if (article == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Entry(article).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Delete article with save in DB
        /// </summary>
        /// <param name="articleId"></param>
        public void DeleteArticle (int articleId)
        {
            var article = context.Articles.FirstOrDefault(x => x.Id == articleId);
            context.Articles.Remove(article ?? throw new InvalidOperationException());
            context.SaveChanges();
        }
    }
}