namespace Application.Interfaces
{
    public delegate void ReceivedMessageEventHandler(MessageSenderRequest messageSenderRequest);
    public interface IRabbitMqConfig
    {
        public event ReceivedMessageEventHandler? OnReceived;
        public void Listen();
    }
}
