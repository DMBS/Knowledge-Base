using KB_DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KB_DAL.Interfaces
{
    /// <summary>
    /// Category interface repository
    /// </summary>
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        IEnumerable<Category> CountOfArticlesInCategory();
        void CreateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
