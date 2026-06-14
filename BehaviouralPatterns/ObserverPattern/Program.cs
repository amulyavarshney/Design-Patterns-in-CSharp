namespace ObserverPattern
{
    // Program class to demonstrate the Observer pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the subject — a stock with an initial price
            var apple = new Stock("AAPL", 150.00f);

            // Create two observers
            var display = new StockDisplay();
            var mobileAlert = new MobileAlert();

            // Register both observers with the stock
            apple.AddObserver(display);
            apple.AddObserver(mobileAlert);

            // Both observers are notified when the price changes
            Console.WriteLine("--- Price changes to $155 ---");
            apple.Price = 155.00f;

            Console.WriteLine("--- Price changes to $160 ---");
            apple.Price = 160.00f;

            // Unregister the mobile alert observer
            apple.RemoveObserver(mobileAlert);

            // Only the display is notified now
            Console.WriteLine("--- Price changes to $145 (MobileAlert unsubscribed) ---");
            apple.Price = 145.00f;
        }
    }
}
