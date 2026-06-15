namespace FactoryMethodPattern
{
    // Concrete product — sends a notification via email
    public class EmailNotification : INotification
    {
        // Send an email notification
        public void Send(string message)
        {
            Console.WriteLine($"Email: {message}");
        }
    }
}
