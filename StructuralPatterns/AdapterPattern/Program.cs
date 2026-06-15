namespace AdapterPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Wrap the legacy processor in the adapter
            var legacyProcessor = new LegacyPaymentProcessor();
            IPaymentProcessor processor = new PaymentAdapter(legacyProcessor);

            // Client calls Pay() — unaware of the legacy system underneath
            processor.Pay(99.99m);
            processor.Pay(149.50m);
        }
    }
}
