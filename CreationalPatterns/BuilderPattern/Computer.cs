namespace BuilderPattern
{
    // The product — a computer assembled from individual parts
    public class Computer
    {
        public string CPU     { get; set; } = string.Empty;
        public string RAM     { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string GPU     { get; set; } = string.Empty;

        // Display all assembled parts
        public void ShowSpecs()
        {
            Console.WriteLine($"  CPU:     {CPU}");
            Console.WriteLine($"  RAM:     {RAM}");
            Console.WriteLine($"  Storage: {Storage}");
            Console.WriteLine($"  GPU:     {GPU}");
        }
    }
}
