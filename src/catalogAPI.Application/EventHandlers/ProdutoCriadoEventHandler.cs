using catalogAPI.Application.DTOs.Requests;
using catalogAPI.Application.Events;
using catalogAPI.Application.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Application.EventHandlers
{
    public class ProdutoCriadoEventHandler : IIntegrationEventHandler<ProdutoCriadoEvent>
    {
        private readonly IProductRepository _repository;

        private readonly ILogger<ProdutoCriadoEventHandler> _logger;

        public ProdutoCriadoEventHandler(IProductRepository repository = null, ILogger<ProdutoCriadoEventHandler> logger = null)
        {
            _repository = repository;
            _logger = logger;
        }


        public Task Handle(ProdutoCriadoEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Recebito evento ás {@event.OccurredAt}");

            try
            {
                var produto = new ProductsRequest
                {
                    CategoryId = @event.CategoryId,
                    Description = @event.Description,
                    Name = @event.Name,
                    IsActive = @event.IsActive,
                    Price = @event.Price
                };

                _repository.CreateProduct(produto);


                _logger.LogInformation("Produto {productName} criado com sucesso no banco", produto.Name);

            } catch(Exception ex)
            {
                _logger.LogError("Erro ao realizar insert do produto no banco, erro> {messageErro}", ex.Message);
            }


            return Task.CompletedTask;

        }
    }
}
