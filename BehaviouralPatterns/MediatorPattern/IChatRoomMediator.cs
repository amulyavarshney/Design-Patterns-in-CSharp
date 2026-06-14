namespace MediatorPattern
{
    // Interface that the mediator must implement
    public interface IChatRoomMediator
    {
        // Register a user with the chat room
        void AddUser(User user);

        // Deliver a message from one user to all others
        void SendMessage(string message, User sender);
    }
}
