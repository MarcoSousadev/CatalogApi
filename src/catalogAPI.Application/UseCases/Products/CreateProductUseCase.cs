using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Interfaces.Repositories;
using catalogAPI.Application.Interfaces.UseCases.Categories;
using catalogAPI.Application.Interfaces.UseCases.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.UseCases.Products
{
    public class CreateProductUseCase : ICreateProductUseCase
    {
        private readonly IProductRepository _repository;

        public CreateProductUseCase(IProductRepository repository)
        {
            _repository = repository;
        }
     

        public async Task Execute(ProductsRequest request)
        {
            if(request.CategoryId.ToString() != null && request.CategoryId > 0)
            {
                await _repository.CreateProduct(request);
            }


            throw new Exception("Erro ao criar produto");
            
        }
    }
}
