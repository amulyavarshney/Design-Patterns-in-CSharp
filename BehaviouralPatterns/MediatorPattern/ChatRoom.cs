namespace MediatorPattern
{
    // Concrete mediator — coordinates communication between users
    public class ChatRoom : IChatRoomMediator
    {
        // List of all registered users
        private List<User> _users = new List<User>();

        // Register a user so they can send and receive messages
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        // Deliver a message to every user except the sender
        public void SendMessage(string message, User sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                    user.Receive(message, sender.Name);
            }
        }
    }
}
