namespace BridgePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Any shape can be combined with any renderer independently
            var vectorCircle  = new Circle(new VectorRenderer());
            var rasterCircle  = new Circle(new RasterRenderer());
            var vectorSquare  = new Square(new VectorRenderer());
            var rasterSquare  = new Square(new RasterRenderer());

            vectorCircle.Draw();
            rasterCircle.Draw();
            vectorSquare.Draw();
            rasterSquare.Draw();
        }
    }
}
