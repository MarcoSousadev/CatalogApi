using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Interfaces;

namespace catalogAPI.Application.UseCases.Categories
{
    public class CreateCategoryUseCase : ICreateCategoryUseCase
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(CategoryRequest request)
        {
            if (request != null)
              await _repository.CreateCategoryAsync(request);
        }
    }
}
