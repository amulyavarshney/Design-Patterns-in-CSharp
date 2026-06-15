namespace BridgePattern
{
    // Concrete implementation — renders shapes as vector graphics
    public class VectorRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as vector graphics");
        }
    }
}
