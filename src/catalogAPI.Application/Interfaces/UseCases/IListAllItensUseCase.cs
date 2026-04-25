using catalogAPI.Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.Interfaces
{
    public interface IListAllItensUseCase
    {
        List<CategoryResponse> Execute(int pageNumber, int pagesQuantity);
    }
}
