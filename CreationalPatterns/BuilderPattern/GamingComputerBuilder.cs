namespace BuilderPattern
{
    // Concrete builder — assembles a high-end gaming computer
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU()     => _computer.CPU     = "Intel Core i9";
        public void SetRAM()     => _computer.RAM     = "32GB DDR5";
        public void SetStorage() => _computer.Storage = "2TB NVMe SSD";
        public void SetGPU()     => _computer.GPU     = "NVIDIA RTX 4090";

        public Computer GetResult() => _computer;
    }
}
