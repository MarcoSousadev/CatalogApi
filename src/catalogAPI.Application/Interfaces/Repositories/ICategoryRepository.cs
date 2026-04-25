using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Domain.Entities.Category;

namespace catalogAPI.Application.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(CategoryRequest category);
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetAllItensPaginatedAsync(int pageNumber, int pageQuantity);
        Task UpdateCategory(int id, CategoryRequest request);

        Task DeleteCategory(int id);

    }
}
