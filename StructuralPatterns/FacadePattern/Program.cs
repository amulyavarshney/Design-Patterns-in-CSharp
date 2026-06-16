namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the subsystem objects
            var amplifier = new Amplifier();
            var projector = new Projector();
            var player    = new StreamingPlayer();

            // Hand them to the facade — client only calls the facade
            var homeTheatre = new HomeTheatreFacade(amplifier, projector, player);

            homeTheatre.WatchMovie("Inception");
            Console.WriteLine();
            homeTheatre.EndMovie();
        }
    }
}
