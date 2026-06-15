namespace AdapterPattern
{
    // The interface the client expects to work with
    public interface IPaymentProcessor
    {
        void Pay(decimal amount);
    }
}
