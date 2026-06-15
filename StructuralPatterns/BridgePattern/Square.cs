namespace BridgePattern
{
    // Refined abstraction — a square that delegates rendering to its renderer
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }

        public override void Draw()
        {
            _renderer.Render("Square");
        }
    }
}
