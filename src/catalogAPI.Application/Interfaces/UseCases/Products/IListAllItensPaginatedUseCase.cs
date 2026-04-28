using catalogAPI.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.Interfaces.UseCases.Products
{
    public interface IListAllItensPaginatedUseCase
    {
        Task<IEnumerable<Product>> Execute(int page, int pageQuantity);
    }
}
