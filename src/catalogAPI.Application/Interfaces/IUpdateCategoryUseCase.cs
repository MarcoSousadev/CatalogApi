using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.DTOs.Responses;

namespace catalogAPI.Application.Interfaces
{
    public interface IUpdateCategoryUseCase
    {
        Task<CategoryResponse> Execute(int id, CategoryRequest request);
    }
}
