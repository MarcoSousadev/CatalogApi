using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalogAPI.Kafka.Consumer.Kafka
{
    public interface IEventTypeRegistry
    {
        IReadOnlyCollection<string> Topics { get; }

        Type GetEventType(string topic);
    }
}
