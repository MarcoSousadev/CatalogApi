using catalogAPI.Application.DTOs.Responses;
using catalogAPI.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.Interfaces
{
    public interface IListAllItensUseCase
    {
        Task<IEnumerable<Category>> Execute(int pageNumber, int pagesQuantity);
    }
}
