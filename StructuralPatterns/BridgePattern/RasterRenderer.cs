namespace BridgePattern
{
    // Concrete implementation — renders shapes as raster (pixel) graphics
    public class RasterRenderer : IRenderer
    {
        public void Render(string shapeName)
        {
            Console.WriteLine($"Drawing {shapeName} as raster pixels");
        }
    }
}
