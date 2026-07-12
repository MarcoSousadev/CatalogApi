using catalogAPI.Consumer.Parameters;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace catalogAPI.Consumer
{
    public class ConsumerService : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly ILogger<ConsumerService> _logger;
        private readonly ConsumerConfig _consumerConfig;
        private readonly ParametersModel _parameter;


        public ConsumerService( ILogger<ConsumerService> logger)
        {
            _logger = logger;
            _parameter = new ParametersModel();      
            _consumerConfig = new ConsumerConfig()
            {
                BootstrapServers = _parameter.BootstrapServer,
                GroupId = _parameter.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Aguardando menssagens");
            _consumer.Subscribe(_parameter.TopicName);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Run(() =>
                {
                    ;
                    var result = _consumer.Consume(stoppingToken);
                    _logger.LogInformation($"GroupId: {_parameter.GroupId} Menssagem: {result.Message.Value}");
                });


            }

        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            _consumer.Close();
            _logger.LogInformation("Aplicacao parou");
            return Task.CompletedTask;
        }
    }
}
