using catalogAPI.Domain.EventsConfig;

namespace catalogAPI.Kafka.Consumer.Kafka
{
    public interface IEventDispatcher
    {
        Task DispatchAsync(
            Type eventType,
            IntegrationEvent integrationEvent,
            CancellationToken cancellationToken);
    }
}
