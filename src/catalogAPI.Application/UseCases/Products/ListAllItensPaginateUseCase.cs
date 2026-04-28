using catalogAPI.Application.Interfaces.Repositories;
using catalogAPI.Application.Interfaces.UseCases.Products;
using catalogAPI.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.UseCases.Products
{
    public class ListAllItensPaginateUseCase : IListAllItensPaginatedUseCase
    {
        private readonly IProductRepository _repository;

        public ListAllItensPaginateUseCase(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> Execute(int page, int pageQuantity)
        {
            await _repository.GetAllItensWithPagination(page, pageQuantity);
        }
    }
}
