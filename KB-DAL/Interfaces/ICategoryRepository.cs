using System.Linq;

namespace KB_DAL.Interfaces
{
    /// <summary>
    /// Category interface repository
    /// </summary>
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
        void CreateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
