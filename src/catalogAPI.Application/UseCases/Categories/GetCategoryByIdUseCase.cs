using catalogAPI.Application.Interfaces;
using catalogAPI.Application.Interfaces.Repository;
using catalogAPI.Domain.Entities.Category;

namespace catalogAPI.Application.UseCases.Categories
{
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {
        private readonly ICategoryRepository _repository;
        public GetCategoryByIdUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Category> Execute(int id)
        {
           var result = await _repository.GetCategoryAsync(id);

            return new Category
            {
                Description = result.Description,
                Id = result.Id,
                Name = result.Name

            };

        }
    }
}
