using catalogAPI.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.Interfaces
{
    public interface IGetCategoryByIdUseCase
    {
        Task<Category> Execute(int id);
    }
}
