namespace ChainOfResponsibilityPattern
{
    // Data class representing a support ticket with a priority level
    public class SupportTicket
    {
        // Unique ticket identifier
        public int Id { get; }

        // Priority: 1 = low, 2 = medium, 3 = high
        public int Priority { get; }

        // Constructor to initialise the ticket
        public SupportTicket(int id, int priority)
        {
            Id       = id;
            Priority = priority;
        }
    }
}
