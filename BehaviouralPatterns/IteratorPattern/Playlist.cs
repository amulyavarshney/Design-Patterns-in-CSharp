namespace IteratorPattern
{
    // Concrete collection — holds a list of songs and creates an iterator for them
    public class Playlist : ICollection
    {
        // Internal list of songs
        private List<string> _songs = new List<string>();

        // Add a song to the playlist
        public void AddSong(string song)
        {
            _songs.Add(song);
        }

        // Return an iterator that traverses the songs
        public IIterator CreateIterator()
        {
            return new PlaylistIterator(_songs);
        }
    }
}
