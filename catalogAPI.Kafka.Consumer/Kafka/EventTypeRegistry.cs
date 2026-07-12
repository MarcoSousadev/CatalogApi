using catalogAPI.Domain.EventsConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Kafka.Consumer.Kafka
{
    public sealed class EventTypeRegistry : IEventTypeRegistry
    {
        private readonly IReadOnlyDictionary<string, Type> _eventsByTopics;

        public EventTypeRegistry(IEnumerable<Type> eventTypes)
        {
            var eventsByTopic = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

            foreach(var eventType in eventTypes)
            {
                var topicAttribute = eventType.GetCustomAttributes(typeof(MessageTopicAttribute), false).Cast<MessageTopicAttribute>().FirstOrDefault();

                if(topicAttribute is null)
                {
                    continue;
                }

                var topic = topicAttribute.Topic;

                if(!eventsByTopic.TryAdd(topic, eventType))
                {
                    var existingEventType = eventsByTopic[topic];

                    throw new InvalidOperationException(
                   $"O tópico '{topic}' foi associado aos eventos " +
                   $"'{existingEventType.Name}' e '{eventType.Name}'.");
                }
            }

            _eventsByTopics = eventsByTopic;
        }

        public IReadOnlyCollection<string> Topics => _eventsByTopics.Keys.ToArray();
        
        public Type GetEventType(string topic)
        {
           if(!_eventsByTopics.TryGetValue(topic, out var eventType))
            {
                throw new InvalidOperationException($"Nenhum evento foi registrado para o tópico '{topic}'.");
            }

            return eventType;
        }
    }
}
