namespace MediatorPattern
{
    // Program class to demonstrate the Mediator pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the mediator
            var chatRoom = new ChatRoom();

            // Create users — each registers itself with the chat room
            var alice = new User("Alice", chatRoom);
            var bob   = new User("Bob",   chatRoom);
            var carol = new User("Carol", chatRoom);

            // Users communicate only through the mediator
            Console.WriteLine("--- Alice sends a message ---");
            alice.Send("Hey everyone!");

            Console.WriteLine();

            Console.WriteLine("--- Bob sends a message ---");
            bob.Send("Hi Alice!");
        }
    }
}
