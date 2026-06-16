namespace DecoratorPattern
{
    // Component interface — implemented by both the base coffee and all decorators
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
}
