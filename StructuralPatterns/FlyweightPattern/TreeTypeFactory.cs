namespace FlyweightPattern
{
    // Flyweight factory — caches and reuses TreeType objects
    public class TreeTypeFactory
    {
        // Cache keyed by a combination of name+colour+texture
        private Dictionary<string, TreeType> _cache = new Dictionary<string, TreeType>();

        // Return a cached TreeType or create a new one if not seen before
        public TreeType GetTreeType(string name, string colour, string texture)
        {
            string key = $"{name}_{colour}_{texture}";
            if (!_cache.ContainsKey(key))
            {
                _cache[key] = new TreeType(name, colour, texture);
                Console.WriteLine($"[Factory] Created new TreeType: {name}");
            }
            return _cache[key];
        }

        // Report how many unique TreeType objects exist
        public int Count => _cache.Count;
    }
}
