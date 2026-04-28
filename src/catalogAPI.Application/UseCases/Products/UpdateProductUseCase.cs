using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Interfaces.Repositories;
using catalogAPI.Application.Interfaces.UseCases.Products;

namespace catalogAPI.Application.UseCases.Products
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _repository;

        public UpdateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(int id, ProductsRequest request)
        {
            await _repository.Update(id, request);
        }
    }
}
