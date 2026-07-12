namespace catalogAPI.Domain.EventsConfig
{
    public abstract class IntegrationEvent 
    {
        public Guid EventId { get; set; } = Guid.NewGuid();
        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    }
}
