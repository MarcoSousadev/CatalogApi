using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.DTOs.Responses;
using catalogAPI.Application.Interfaces;

namespace catalogAPI.Application.UseCases.Categories
{
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        public Task<CategoryResponse> Execute(int id, CategoryRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
