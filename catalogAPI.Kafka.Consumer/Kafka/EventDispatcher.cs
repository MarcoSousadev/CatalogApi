using catalogAPI.Application.Events;
using catalogAPI.Domain.EventsConfig;
using Microsoft.Extensions.DependencyInjection;

namespace catalogAPI.Kafka.Consumer.Kafka
{
    public sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventDispatcher(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        public async Task DispatchAsync(Type eventType, IntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            await using var scope = _scopeFactory.CreateAsyncScope();

            var handlerInterface = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);

            var handlers = scope.ServiceProvider.GetServices(handlerInterface).ToArray();

            if(handlers.Length == 0)
            {
                throw new InvalidOperationException($"Nenhum handler foi encontrado para " +
                $"o evento '{eventType.Name}'.");

            }

            var handlerMethod = handlerInterface.GetMethod("Handle");

            if(handlerMethod is null)
            {
                throw new InvalidOperationException(@$"O método handle não foi encontrado
                                                       em '{handlerInterface.Name}'.");

            }

            foreach (var handler in handlers)
            {
                var result = handlerMethod.Invoke(handler, new object[]
                {
                    integrationEvent,
                    cancellationToken
                });

                if(result is not Task task)
                {
                    throw new InvalidOperationException(@$"O handler '{handler.GetType().Name}' 
                                                        não retornou uma Task.");
                }

                await task;
            }


        }
    }
}
