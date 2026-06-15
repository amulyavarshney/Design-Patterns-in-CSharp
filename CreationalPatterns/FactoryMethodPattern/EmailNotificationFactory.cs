namespace FactoryMethodPattern
{
    // Concrete creator — creates EmailNotification objects
    public class EmailNotificationFactory : NotificationFactory
    {
        // Override the factory method to return an EmailNotification
        public override INotification CreateNotification()
        {
            return new EmailNotification();
        }
    }
}
