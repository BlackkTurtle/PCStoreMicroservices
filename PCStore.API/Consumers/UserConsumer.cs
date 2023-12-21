using System.Text;
using System.Text.Json;
using Azure;
using MassTransit;
using PCStoreService.API.Controllers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PCStore.API.Consumers
{
    public class UserConsumer
    {
        private readonly IUserState userState;
        public UserConsumer(IUserState userState)
        {
            this.userState = userState;
        }
        public async Task Consume()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",
                UserName = "user",
                Password = "mypass",
                VirtualHost = "/"
            };
            var conn = factory.CreateConnection();
            using var channel = conn.CreateModel();
            channel.QueueDeclare("pcstorequeue", durable: true, exclusive: false);
            var consumer=new EventingBasicConsumer(channel);
            UserPublisher message=new UserPublisher();
            consumer.Received += (model, eventargs) =>
            {
                var body=eventargs.Body.ToArray();
                message = JsonSerializer.Deserialize<UserPublisher>(body);
            };
            channel.BasicConsume("pcstorequeue",true,consumer);
            userState.HandleUser(message);
        }
    }
}
