using catalogAPI.Domain.EventsConfig;

namespace catalogAPI.Application.Events
{
    public interface IIntegrationEventHandler<in TEvent>
        where TEvent : IntegrationEvent
    {
        Task Handle(TEvent integrationEvent, CancellationToken cancellationToken);
    }
}
