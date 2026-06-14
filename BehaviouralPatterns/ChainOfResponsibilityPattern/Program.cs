namespace ChainOfResponsibilityPattern
{
    // Program class to demonstrate the Chain of Responsibility pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build the chain: FrontDesk → Supervisor → Manager
            var frontDesk  = new FrontDesk();
            var supervisor = new Supervisor();
            var manager    = new Manager();

            frontDesk.SetNext(supervisor).SetNext(manager);

            // Send tickets of different priorities down the chain
            var tickets = new[]
            {
                new SupportTicket(1, 1), // low    — handled by FrontDesk
                new SupportTicket(2, 2), // medium — handled by Supervisor
                new SupportTicket(3, 3), // high   — handled by Manager
                new SupportTicket(4, 4), // unknown — no handler can resolve it
            };

            foreach (var ticket in tickets)
                frontDesk.Handle(ticket);
        }
    }
}
