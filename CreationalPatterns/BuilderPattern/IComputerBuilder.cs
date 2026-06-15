namespace BuilderPattern
{
    // Interface declaring each construction step
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        void SetGPU();

        // Return the finished product
        Computer GetResult();
    }
}
