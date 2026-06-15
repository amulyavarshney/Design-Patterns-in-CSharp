namespace AdapterPattern
{
    // Existing class with an incompatible interface — cannot be modified
    public class LegacyPaymentProcessor
    {
        // Different method name and signature from what the client expects
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Legacy system: processing payment of ${amount}");
        }
    }
}
