using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.Interfaces.UseCases.Products
{
    public interface IDeleteProductUseCase
    {
        Task Execute(int id);
    }
}
