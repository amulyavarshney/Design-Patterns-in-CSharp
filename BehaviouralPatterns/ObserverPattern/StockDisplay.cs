namespace ObserverPattern
{
    // Concrete Observer — displays price updates on a stock market screen
    class StockDisplay : IObserver
    {
        // Called by the subject whenever the stock price changes
        public void Update(string stockName, float price)
        {
            Console.WriteLine($"[Stock Display] {stockName}: ${price}");
        }
    }
}
