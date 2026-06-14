namespace ObserverPattern
{
    // Interface that all observers must implement
    public interface IObserver
    {
        // Called by the subject whenever its state changes
        void Update(string stockName, float price);
    }
}
