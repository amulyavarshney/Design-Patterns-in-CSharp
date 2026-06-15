namespace FactoryMethodPattern
{
    // Concrete creator — creates SmsNotification objects
    public class SmsNotificationFactory : NotificationFactory
    {
        // Override the factory method to return an SmsNotification
        public override INotification CreateNotification()
        {
            return new SmsNotification();
        }
    }
}
