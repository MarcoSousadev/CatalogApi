using catalogAPI.Application.DTOs.Requests;

namespace catalogAPI.Application.Interfaces
{
    public interface ICreateCategoryUseCase
    {
        Task Execute(CategoryRequest request);
    }
}
