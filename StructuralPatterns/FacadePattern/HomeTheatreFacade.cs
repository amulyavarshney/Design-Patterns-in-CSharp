namespace FacadePattern
{
    // Facade — provides a simple interface over the complex subsystem
    public class HomeTheatreFacade
    {
        private Amplifier      _amplifier;
        private Projector      _projector;
        private StreamingPlayer _player;

        public HomeTheatreFacade(Amplifier amplifier, Projector projector, StreamingPlayer player)
        {
            _amplifier = amplifier;
            _projector = projector;
            _player    = player;
        }

        // One method replaces many subsystem calls
        public void WatchMovie(string movie)
        {
            Console.WriteLine("--- Getting ready to watch a movie ---");
            _amplifier.On();
            _amplifier.SetVolume(10);
            _projector.On();
            _projector.WideScreen();
            _player.On();
            _player.Play(movie);
        }

        // One method shuts everything down
        public void EndMovie()
        {
            Console.WriteLine("--- Shutting down the home theatre ---");
            _player.Stop();
            _player.Off();
            _projector.Off();
            _amplifier.Off();
        }
    }
}
