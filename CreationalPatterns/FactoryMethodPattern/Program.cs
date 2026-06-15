namespace FactoryMethodPattern
{
    // Program class to demonstrate the Factory Method pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use the email factory — client code never calls new EmailNotification()
            NotificationFactory factory = new EmailNotificationFactory();
            factory.Notify("Your order has been placed.");

            // Swap to the SMS factory — no other code changes needed
            factory = new SmsNotificationFactory();
            factory.Notify("Your order has been shipped.");
        }
    }
}
