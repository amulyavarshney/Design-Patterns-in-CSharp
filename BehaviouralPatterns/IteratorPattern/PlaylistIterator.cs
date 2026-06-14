namespace IteratorPattern
{
    // Concrete iterator — traverses a list of songs in order
    public class PlaylistIterator : IIterator
    {
        // The list of songs to iterate over
        private List<string> _songs;

        // Current position in the list
        private int _index = 0;

        // Constructor receives the list from the Playlist
        public PlaylistIterator(List<string> songs)
        {
            _songs = songs;
        }

        // Returns true if there are more songs to play
        public bool HasNext()
        {
            return _index < _songs.Count;
        }

        // Returns the next song and advances the position
        public string Next()
        {
            return _songs[_index++];
        }
    }
}
