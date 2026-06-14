namespace ChainOfResponsibilityPattern
{
    // Concrete handler — handles medium priority tickets (priority 2)
    public class Supervisor : SupportHandler
    {
        // Handle the ticket if priority is medium; otherwise pass it up the chain
        public override void Handle(SupportTicket ticket)
        {
            if (ticket.Priority == 2)
                Console.WriteLine($"Supervisor resolved ticket #{ticket.Id} (priority {ticket.Priority})");
            else
                base.Handle(ticket);
        }
    }
}
