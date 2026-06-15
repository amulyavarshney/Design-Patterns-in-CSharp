namespace AdapterPattern
{
    // Adapter — wraps the legacy processor and exposes the expected interface
    public class PaymentAdapter : IPaymentProcessor
    {
        // Reference to the incompatible legacy system
        private LegacyPaymentProcessor _legacyProcessor;

        // Constructor receives the legacy processor to wrap
        public PaymentAdapter(LegacyPaymentProcessor legacyProcessor)
        {
            _legacyProcessor = legacyProcessor;
        }

        // Translate the client's Pay() call into the legacy ProcessPayment() call
        public void Pay(decimal amount)
        {
            _legacyProcessor.ProcessPayment(amount);
        }
    }
}
