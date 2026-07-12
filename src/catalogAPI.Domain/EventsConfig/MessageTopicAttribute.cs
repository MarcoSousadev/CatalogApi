namespace catalogAPI.Domain.EventsConfig
{
    [AttributeUsage(AttributeTargets.Class,
        AllowMultiple = false,
        Inherited = false)]
    public sealed class MessageTopicAttribute : Attribute
    {
        public MessageTopicAttribute(string topic)
        {
            if (String.IsNullOrEmpty(topic))
                throw new ArgumentException("O tópico não pode ser vazio", nameof(topic));


            Topic = topic;
        }

        public string Topic { get; }
    }
}
    