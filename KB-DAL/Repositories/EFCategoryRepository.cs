using KB_DAL.Entities;
using KB_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KB_DAL.Repositories
{
    /// <summary>
    /// Category repository with CRUD operation and save domain categories in Database
    /// </summary>
    public class EFCategoryRepository : ICategoryRepository
    {
        private KBEntities context = new KBEntities();

        public IQueryable<Category> Categories
        {
            get
            {
                return context.Categories;
            }
        }

        public IEnumerable<Category> CountOfArticlesInCategory()
        {
            var query = from c in context.Categories
                        join a in context.Articles
                        on c.Id equals a.Category_Id
                        into subs
                        from sub in subs.DefaultIfEmpty()
                        group sub by new { c.Id, c.Name, c.Badge, sub.Category_Id }
                        into grp
                        orderby grp.Count() descending
                        select new
                        {
                            grp.Key.Id,
                            grp.Key.Name,
                            grp.Key.Badge,
                            Count = grp.Count(x=>x !=null)
                        };

            var result = query.ToList()
            .Select(e => new Category
             {
                Id = e.Id,
                Name = e.Name,
                Badge = e.Badge,
                ArticlesCount = e.Count

            }).ToList();
             
            return result ;

            //var query = from c in context.Categories
            //            join a in context.Articles
            //            on c.Id equals a.Id
            //            group c by a.Category_Id into g
            //            select new Category
            //            {
            //                Id = g.Select(x => x.Id).ToList(),
            //                Name = g.Select(x => x.Name).ToList(), 
            //                Badge = g.Select(x => x.Badge).ToList(),
            //            }
            //var query = context
            //    .Database
            //    .SqlQuery<PostEntity>(
            //    "SELECT COUNT(a.Category_Id) AS ArticlesCount FROM Categories c LEFT JOIN Articles a ON c.id = a.Category_Id GROUP BY c.Id, c.[Name], c.Badge ORDER BY c.[Id]")
            //    .ToList();

            //var result = query.ToList()
            //    .Select(e => new PostEntity
            //    {
            //        Categories.Id = e.Categories,
            //        Name = e.Name,
            //        Badge = e.Badge,
            //        ArticlesCount = e.ArticlesCount
            //    })
            //    .ToList();

            //return rt;
        }

        /// <summary>
        /// Create Category with save in DB
        /// </summary>
        /// <param name="category"></param>
        public void CreateCategory(Category category)
        {
            if (category == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// Delete Category with save in DB
        /// </summary>
        /// <param name="CategoryId"></param>
        public void DeleteCategory (int CategoryId)
        {
            Category dbEntry = context.Categories.Find(CategoryId);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}