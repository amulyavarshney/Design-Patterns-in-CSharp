namespace SingletonPattern
{
    // Program class to demonstrate the Singleton pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Both variables point to the same instance
            var config1 = ConfigurationManager.Instance;
            var config2 = ConfigurationManager.Instance;

            // Prove they are the same object
            Console.WriteLine($"Same instance: {ReferenceEquals(config1, config2)}"); // True

            // Read default settings from the first reference
            Console.WriteLine($"Theme: {config1.Get("Theme")}");       // Dark
            Console.WriteLine($"Language: {config1.Get("Language")}");  // English

            // Update a setting through the second reference
            config2.Set("Theme", "Light");

            // Change is visible through the first reference — same object
            Console.WriteLine($"Theme after update: {config1.Get("Theme")}"); // Light
        }
    }
}
