namespace DecoratorPattern
{
    // Concrete component — the base object being decorated
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost()        => 1.00;
    }
}
