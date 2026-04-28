using catalogAPI.Application.DTOs.Requests;

namespace catalogAPI.Application.Interfaces.UseCases.Products
{
    public interface ICreateProductUseCase
    {
        Task Execute(ProductsRequest request);
    }
}
