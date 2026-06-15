namespace BuilderPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var director = new ComputerDirector();

            // Build a gaming computer
            var gamingBuilder = new GamingComputerBuilder();
            director.Build(gamingBuilder);
            Console.WriteLine("Gaming Computer:");
            gamingBuilder.GetResult().ShowSpecs();

            Console.WriteLine();

            // Build an office computer — same director, different builder
            var officeBuilder = new OfficeComputerBuilder();
            director.Build(officeBuilder);
            Console.WriteLine("Office Computer:");
            officeBuilder.GetResult().ShowSpecs();
        }
    }
}
