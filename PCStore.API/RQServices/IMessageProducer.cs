namespace PCStore.API.RQServices
{
    public interface IMessageProducer
    {
        public void SendingMessage<T>(T message);
    }
}
