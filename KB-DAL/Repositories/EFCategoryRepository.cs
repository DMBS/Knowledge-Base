using KB_DAL.Interfaces;
using System;
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