using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace UserManager.API.Messages
{
    public class MessageProducer : IMessageProducer
    {
        public async Task SendingMessage<T>(T message)
        {
            var factory=new ConnectionFactory()
            {
                HostName = "rabbitmq",
                UserName="user",
                Password="mypass",
                VirtualHost="/"
            };
            var conn = factory.CreateConnection();

            using var channel=conn.CreateModel();
            channel.QueueDeclare("pcstorequeue",durable:true,exclusive:false);

            var jsonString=JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
            channel.BasicPublish("","pcstorequeue",body:body);
        }
    }
}
