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
    public class GetProductByIdUseCase : IGetProcutByIdUseCase
    {
        private readonly IProductRepository _repository;

        public GetProductByIdUseCase(IProductRepository repository)
        {
            _repository = repository; 
        }
        public async Task<Product> Execute(int id)
        {
            var response = await _repository.GetById(id);

            if (response != null)
            {
                return response;
            }

            throw new Exception($"Produto com id: {id} , não encontrado");
        }
    }
}
