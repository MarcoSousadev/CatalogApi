using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.DTOs.Responses;
using catalogAPI.Application.Interfaces;
using catalogAPI.Application.Interfaces.Repository;
using catalogAPI.Domain.Entities.Category;

namespace catalogAPI.Application.UseCases.Categories
{
    public class UpdateCategoryUseCase : IUpdateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public UpdateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(int id, CategoryRequest request)
        {
             await _repository.UpdateCategory(id, request);
        }
    }
}
