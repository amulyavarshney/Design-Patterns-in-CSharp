namespace IteratorPattern
{
    // Program class to demonstrate the Iterator pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a playlist and add songs
            var playlist = new Playlist();
            playlist.AddSong("Bohemian Rhapsody");
            playlist.AddSong("Hotel California");
            playlist.AddSong("Stairway to Heaven");

            // Get an iterator — the caller never touches the internal list
            var iterator = playlist.CreateIterator();

            // Traverse using only HasNext() and Next()
            Console.WriteLine("Playing playlist:");
            while (iterator.HasNext())
                Console.WriteLine($"  Now playing: {iterator.Next()}");
        }
    }
}
