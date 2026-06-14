namespace ChainOfResponsibilityPattern
{
    // Concrete handler — handles low priority tickets (priority 1)
    public class FrontDesk : SupportHandler
    {
        // Handle the ticket if priority is low; otherwise pass it up the chain
        public override void Handle(SupportTicket ticket)
        {
            if (ticket.Priority == 1)
                Console.WriteLine($"FrontDesk resolved ticket #{ticket.Id} (priority {ticket.Priority})");
            else
                base.Handle(ticket);
        }
    }
}
