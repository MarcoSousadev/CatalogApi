using catalogAPI.Domain.EventsConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Kafka
{
    public sealed class EventTypeRegistry : IEventTypeRegistry
    {
        private readonly IReadOnlyDictionary<string, Type> _eventsByTopic;

        public EventTypeRegistry(IEnumerable<Type> eventTypes)
        {
            var dictionary = new Dictionary<string, Type>(
                StringComparer.OrdinalIgnoreCase);

           foreach(var eventType in eventTypes)
            {
                var topic = eventType.GetMessageTopic();

                if (!dictionary.TryAdd(topic, eventType))
                {
                    var registeredType = dictionary[topic];

                    throw new InvalidOperationException(
                    $"O tópico '{topic}' está declarado em mais de um evento: " +
                    $"{registeredType.Name} e {eventType.Name}.");
                }
            }

            _eventsByTopic = dictionary;
            
        }

        public IReadOnlyCollection<string> Topics => _eventsByTopic.Keys.ToArray();

        public Type GetEventType(string topic)
        {
            if(!_eventsByTopic.TryGetValue(topic, out var eventType))
            {
                throw new InvalidOperationException($"Nenhum evento foi registrado para o tópico '{topic}'");
            }

            return eventType;
        }
    }
}
