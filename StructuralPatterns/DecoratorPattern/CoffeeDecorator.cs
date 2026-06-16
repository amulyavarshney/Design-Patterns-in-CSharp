namespace DecoratorPattern
{
    // Abstract decorator — wraps an ICoffee and delegates to it
    public abstract class CoffeeDecorator : ICoffee
    {
        // The wrapped component (could be a SimpleCoffee or another decorator)
        protected ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        // Default delegation — concrete decorators override to add behaviour
        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost()        => _coffee.GetCost();
    }
}
