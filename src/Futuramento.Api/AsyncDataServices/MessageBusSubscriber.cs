using Faturamento.Api.EventProcessing;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Faturamento.Api.AsyncDataServices
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IProcessaFaturamento _processaFarturamento;
        private IConnection _connection;
        private IModel _channel;
        private string _nomeDaFila;

        public MessageBusSubscriber(IConfiguration configuration, IProcessaFaturamento processaFaturamento)
        {
            _configuration = configuration;
            _processaFarturamento = processaFaturamento;
            IniciaRabbitMQ();
        }

        private void IniciaRabbitMQ()
        {
            _connection = new ConnectionFactory() { HostName = "localhost", Port = 8002 }.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "faturamento", type: ExchangeType.Fanout);
            _nomeDaFila = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(queue: _nomeDaFila,
                exchange: "faturamento",
                routingKey: "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                var body = ea.Body;
                var mensagem = Encoding.UTF8.GetString(body.ToArray());

                _processaFarturamento.ProcessaFaturamento(mensagem);
            };

            _channel.BasicConsume(queue: _nomeDaFila, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }
    }
}
