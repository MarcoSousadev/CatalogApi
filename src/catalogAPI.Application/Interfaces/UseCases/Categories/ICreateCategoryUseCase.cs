using catalogAPI.Application.DTOs.Requests;

namespace catalogAPI.Application.Interfaces.UseCases.Categories
{
    public interface ICreateCategoryUseCase
    {
        Task Execute(CategoryRequest request);
    }
}
