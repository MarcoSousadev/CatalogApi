using catalogAPI.Application.Interfaces;
using catalogAPI.Application.Interfaces.Repository;
using catalogAPI.Application.Interfaces.UseCases.Categories;

namespace catalogAPI.Application.UseCases.Categories
{
    public class RemoveCategoryUseCase : IRemoveCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(int id)
        {
            await _repository.DeleteCategory(id);
        }
    }
}
