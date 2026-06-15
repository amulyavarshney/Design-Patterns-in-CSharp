namespace FactoryMethodPattern
{
    // Interface that all notification products must implement
    public interface INotification
    {
        // Send the notification with the given message
        void Send(string message);
    }
}
