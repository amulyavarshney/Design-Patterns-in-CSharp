namespace BuilderPattern
{
    // Concrete builder — assembles a budget office computer
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU()     => _computer.CPU     = "Intel Core i5";
        public void SetRAM()     => _computer.RAM     = "16GB DDR4";
        public void SetStorage() => _computer.Storage = "512GB SSD";
        public void SetGPU()     => _computer.GPU     = "Intel Integrated Graphics";

        public Computer GetResult() => _computer;
    }
}
