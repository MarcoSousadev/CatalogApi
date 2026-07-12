using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Domain.EventsConfig
{
    public static class MessageTopicExtensions
    {
        public static string GetMessageTopic(this Type eventType)
        {
            var attribute = eventType.GetCustomAttribute<MessageTopicAttribute>();

            if (attribute is null)
            {
                throw new InvalidOperationException($" o evento {eventType.Name} não possui o atributo" + $"[{nameof(MessageTopicAttribute)}].");
            }

            return attribute.Topic;
        }
    

        public static string GetMessageTopic<TEvent>()
            where TEvent : IntegrationEvent
        {
            return typeof(TEvent).GetMessageTopic();
        }
    }
}
