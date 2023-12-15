namespace PCStore.API.Consumers
{
    public class UserState:IUserState
    {
        public bool Isregisterd { get; set; } =false;
        public string? Username { get; set; } =null;

        public void HandleUser(UserPublisher userPublisher)
        {
            Isregisterd = userPublisher.IsRegistered;
            Username=userPublisher.UserName;
        }
    }
}
