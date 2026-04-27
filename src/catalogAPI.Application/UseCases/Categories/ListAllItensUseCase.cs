using catalogAPI.Application.DTOs.Responses;
using catalogAPI.Application.Interfaces;
using catalogAPI.Application.Interfaces.Repository;
using catalogAPI.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.UseCases.Categories
{
    public class ListAllItensUseCase : IListAllItensUseCase
    {
        private readonly ICategoryRepository _repository;
        public ListAllItensUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Category>> Execute(int pageNumber, int pagesQuantity)
        {
            return await _repository.GetAllItensPaginatedAsync(pageNumber, pagesQuantity);
        }

       
    }
}
