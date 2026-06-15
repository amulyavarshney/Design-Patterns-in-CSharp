namespace BuilderPattern
{
    // Director — defines the order of construction steps
    public class ComputerDirector
    {
        // Build a complete computer using the given builder
        public void Build(IComputerBuilder builder)
        {
            builder.SetCPU();
            builder.SetRAM();
            builder.SetStorage();
            builder.SetGPU();
        }
    }
}
