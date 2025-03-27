namespace UserManager.API.Messages
{
    public interface IMessageProducer
    {
        public Task SendingMessage<T>(T message);
    }
}
