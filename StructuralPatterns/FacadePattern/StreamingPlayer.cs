namespace FacadePattern
{
    // Subsystem class — controls the streaming player
    public class StreamingPlayer
    {
        public void On()             => Console.WriteLine("StreamingPlayer: turning on");
        public void Off()            => Console.WriteLine("StreamingPlayer: turning off");
        public void Play(string movie) => Console.WriteLine($"StreamingPlayer: playing \"{movie}\"");
        public void Stop()           => Console.WriteLine("StreamingPlayer: stopping");
    }
}
