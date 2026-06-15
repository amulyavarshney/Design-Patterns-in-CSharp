namespace FactoryMethodPattern
{
    // Concrete product — sends a notification via SMS
    public class SmsNotification : INotification
    {
        // Send an SMS notification
        public void Send(string message)
        {
            Console.WriteLine($"SMS: {message}");
        }
    }
}
