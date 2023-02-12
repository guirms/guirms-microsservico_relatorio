namespace Application.Interfaces
{
    public interface IRabbitMqConfig
    {
        public delegate void ReceivedMessageEventHandler(MessageSenderRequest messageSenderRequest);
        public event ReceivedMessageEventHandler? OnReceived;
        public void Listen();
    }
}
