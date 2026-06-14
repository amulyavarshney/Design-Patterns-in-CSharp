namespace ObserverPattern
{
    // Interface that the subject (observable) must implement
    public interface ISubject
    {
        // Register an observer to receive notifications
        void AddObserver(IObserver observer);

        // Remove an observer so it no longer receives notifications
        void RemoveObserver(IObserver observer);

        // Notify all registered observers of a state change
        void NotifyObservers();
    }
}
