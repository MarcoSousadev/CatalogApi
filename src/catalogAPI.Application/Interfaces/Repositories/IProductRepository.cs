using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Domain.Entities.Product;

namespace catalogAPI.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task CreateProduct(ProductsRequest request);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAllItensWithPagination(int pageNumber, int pageQuantity);
        Task Update(int id, ProductsRequest request);
        Task Delete(int id);

    }
}
