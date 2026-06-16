namespace DecoratorPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start with a plain coffee
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} — ${coffee.GetCost():F2}");

            // Wrap it with milk
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} — ${coffee.GetCost():F2}");

            // Wrap it again with sugar
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} — ${coffee.GetCost():F2}");

            // Decorators can be stacked in any order — add a second milk
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} — ${coffee.GetCost():F2}");
        }
    }
}
