using Confluent.Kafka;

namespace catalogAPI.Producer
{
    public class ProducerService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProducerService> _logger;
        private readonly ProducerConfig _kafkaConfig;

        public ProducerService(IConfiguration configuration, ILogger<ProducerService> logger)
        {
            _configuration = configuration;

            _logger = logger;

            var bootstrapserver = _configuration.GetSection("KafkaConfig").GetSection("BootstrapServer").Value;

            _kafkaConfig = new ProducerConfig()
            {
                BootstrapServers = bootstrapserver
            };
        }

        public async Task<string> SendMessage(string message)
        {
            using (var producer = new ProducerBuilder<Null, string>(_kafkaConfig).Build())
            {
                try
                {
                    var topic = _configuration.GetSection("KafkaConfig").GetSection("TopicName").Value;
                    var result = await producer.ProduceAsync(topic: topic, new Message<Null, string> { Value = message });
                    _logger.LogInformation("Delivered {result.Value} to {result.TopicPartitionOffset}", result.Value, result.TopicPartitionOffset);

                    return result.Status.ToString() + " - " + message;

                } catch (ProduceException<Null, string> ex)
                {
                    _logger.LogError("Delivery failed: {ex.Error.Reason}", ex.Error.Reason);

                    throw;
                }
            }
        }
    }
}
