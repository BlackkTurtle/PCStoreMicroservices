using Azure;
using MassTransit;
using PCStoreService.API.Controllers;

namespace PCStore.API.Consumers
{
    public class UserConsumer : IConsumer<UserPublisher>
    {
        private readonly IUserState userState;
        public UserConsumer(IUserState userState)
        {
            this.userState = userState;
        }
        public async Task Consume(ConsumeContext<UserPublisher> context)
        {
            userState.HandleUser(context.Message);
        }
    }
}
