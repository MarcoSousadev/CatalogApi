using catalogAPI.Application.Interfaces.Repositories;
using catalogAPI.Application.Interfaces.UseCases.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.UseCases.Products
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductRepository _repository;

        public DeleteProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task Execute(int id)
        {
            await _repository.Delete(id);
        }
    }
}
