namespace MediatorPattern
{
    // Colleague — communicates with other users only through the mediator
    public class User
    {
        // The user's display name
        public string Name { get; }

        // Reference to the mediator — the only dependency this class has
        private IChatRoomMediator _mediator;

        // Constructor registers the user with the mediator
        public User(string name, IChatRoomMediator mediator)
        {
            Name      = name;
            _mediator = mediator;
            _mediator.AddUser(this);
        }

        // Send a message via the mediator — never calls other users directly
        public void Send(string message)
        {
            Console.WriteLine($"{Name} sends: \"{message}\"");
            _mediator.SendMessage(message, this);
        }

        // Receive a message delivered by the mediator
        public void Receive(string message, string senderName)
        {
            Console.WriteLine($"{Name} receives from {senderName}: \"{message}\"");
        }
    }
}
