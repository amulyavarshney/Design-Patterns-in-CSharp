namespace ObserverPattern
{
    // The Subject — holds state and notifies observers when it changes
    class Stock : ISubject
    {
        // List of all registered observers
        private List<IObserver> _observers = new List<IObserver>();

        // Name of the stock (e.g. "AAPL")
        public string Name { get; }

        // Backing field for Price so we can trigger notifications on change
        private float _price;
        public float Price
        {
            get => _price;
            set
            {
                _price = value;
                // Automatically notify all observers whenever the price changes
                NotifyObservers();
            }
        }

        // Constructor to set the stock name and initial price
        public Stock(string name, float initialPrice)
        {
            Name = name;
            _price = initialPrice;
        }

        // Register an observer to receive price updates
        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        // Unregister an observer so it stops receiving updates
        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        // Push the current price to every registered observer
        public void NotifyObservers()
        {
            foreach (var observer in _observers)
                observer.Update(Name, _price);
        }
    }
}
