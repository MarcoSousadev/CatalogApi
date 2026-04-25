using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Domain.Entities.Category;

namespace catalogAPI.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(CategoryRequest category);
        Task<Category> GetCategoryAsync(int id);
    }
}
