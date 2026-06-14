namespace ChainOfResponsibilityPattern
{
    // Concrete handler — handles high priority tickets (priority 3)
    public class Manager : SupportHandler
    {
        // Handle the ticket if priority is high; otherwise pass it up the chain
        public override void Handle(SupportTicket ticket)
        {
            if (ticket.Priority == 3)
                Console.WriteLine($"Manager resolved ticket #{ticket.Id} (priority {ticket.Priority})");
            else
                base.Handle(ticket);
        }
    }
}
