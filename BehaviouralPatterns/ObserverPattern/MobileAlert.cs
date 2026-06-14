namespace ObserverPattern
{
    // Concrete Observer — sends a push notification to a mobile device
    class MobileAlert : IObserver
    {
        // Called by the subject whenever the stock price changes
        public void Update(string stockName, float price)
        {
            Console.WriteLine($"[Mobile Alert] Push notification: {stockName} is now ${price}");
        }
    }
}
