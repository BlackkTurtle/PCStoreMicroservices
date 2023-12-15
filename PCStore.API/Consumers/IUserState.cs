namespace PCStore.API.Consumers
{
    public interface IUserState
    {
        public bool Isregisterd { get; set;  }
        public string? Username { get; set;  }
        void HandleUser(UserPublisher userPublisher);
    }
}
