namespace FactoryMethodPattern
{
    // Abstract creator — declares the factory method subclasses must implement
    public abstract class NotificationFactory
    {
        // Factory method — subclasses decide which product to create
        public abstract INotification CreateNotification();

        // Notify method uses the factory method — never mentions a concrete type
        public void Notify(string message)
        {
            var notification = CreateNotification();
            notification.Send(message);
        }
    }
}
