using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Application.RabbitMQ
{
    public sealed class RabbitMqConfig : IDisposable, IRabbitMqConfig
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName;
        private readonly string _exchangeName;
        private readonly string _rountingKey;
        private const string _type = "direct";

        public RabbitMqConfig(IConfiguration configuration)
        {
            _queueName = configuration["RabbitMQ:QueueName"] ?? throw new NullReferenceException("Fila não encontrada");
            _exchangeName = configuration["RabbitMQ:ExchangeName"] ?? throw new NullReferenceException("Exchange não encontrada");
            _rountingKey = configuration["RabbitMQ:RoutingKey"] ?? throw new NullReferenceException("Chave de rota não encontrada");

            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ:HostName"],
                UserName = configuration["RabbitMQ:UserName"],
                Password = configuration["RabbitMQ:Password"],
                Port = Convert.ToInt16(configuration["RabbitMQ:Port"])
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public event ReceivedMessageEventHandler? OnReceived;

        public void Listen()
        {
            _channel.ExchangeDeclare(
                exchange: _exchangeName,
                type: _type,
                durable: true,
                autoDelete: false,
                arguments: null
            );

            _channel.QueueDeclare(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            _channel.QueueBind(_queueName, _exchangeName, _rountingKey);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (_, eventArgs) =>
            {
                try
                {
                    var bytes = eventArgs.Body.ToArray();
                    var data = Encoding.UTF8.GetString(bytes);
                    OnReceived?.Invoke(new MessageSenderRequest(int.Parse(data)));

                    _channel.BasicAck(eventArgs.DeliveryTag, false);
                }
                catch
                {
                    _channel.BasicNack(eventArgs.DeliveryTag, false, true);
                }
            };

            _channel.BasicConsume(
                queue: _queueName,
                autoAck: false,
                exclusive: false,
                arguments: null,
                consumer: consumer
            );
        }

        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
