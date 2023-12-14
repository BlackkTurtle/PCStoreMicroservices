using RabbitMQ.Client;

namespace PCStore.API.RQServices
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory= new ConnectionFactory()
            {
                HostName = "localhost",
                UserName="user",
                Password="mypass",
                VirtualHost="/"
            };
            var conn = factory.CreateConnection();
        }
    }
}
