namespace SingletonPattern
{
    // Singleton class — only one instance can ever exist
    public class ConfigurationManager
    {
        // The single instance, created once on first access
        private static ConfigurationManager? _instance;

        // Lock object ensures thread-safe creation
        private static readonly object _lock = new object();

        // Settings dictionary holds key-value configuration pairs
        private Dictionary<string, string> _settings = new Dictionary<string, string>();

        // Private constructor prevents instantiation from outside this class
        private ConfigurationManager()
        {
            // Load default settings
            _settings["Theme"]    = "Dark";
            _settings["Language"] = "English";
            _settings["Version"]  = "1.0.0";
        }

        // Static property returns the single instance, creating it if needed
        public static ConfigurationManager Instance
        {
            get
            {
                // Double-checked locking for thread safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new ConfigurationManager();
                    }
                }
                return _instance;
            }
        }

        // Retrieve a setting value by key
        public string Get(string key)
        {
            return _settings[key];
        }

        // Update a setting value by key
        public void Set(string key, string value)
        {
            _settings[key] = value;
        }
    }
}
