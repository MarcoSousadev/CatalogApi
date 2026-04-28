using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.DTOs.Responses;
using catalogAPI.Domain.Entities.Category;

namespace catalogAPI.Application.Interfaces
{
    public interface IUpdateCategoryUseCase
    {
        Task Execute(int id, CategoryRequest request);
    }
}
