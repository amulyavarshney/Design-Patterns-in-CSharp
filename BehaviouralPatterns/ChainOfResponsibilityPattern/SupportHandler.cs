namespace ChainOfResponsibilityPattern
{
    // Abstract handler — defines the chain link and the handling interface
    public abstract class SupportHandler
    {
        // Reference to the next handler in the chain
        private SupportHandler? _next;

        // Set the next handler and return it to allow fluent chaining
        public SupportHandler SetNext(SupportHandler next)
        {
            _next = next;
            return next;
        }

        // Handle the ticket or pass it to the next handler
        public virtual void Handle(SupportTicket ticket)
        {
            if (_next != null)
                _next.Handle(ticket);
            else
                Console.WriteLine($"Ticket #{ticket.Id} (priority {ticket.Priority}) could not be handled.");
        }
    }
}
