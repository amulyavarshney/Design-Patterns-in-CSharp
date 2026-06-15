namespace BridgePattern
{
    // Refined abstraction — a circle that delegates rendering to its renderer
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }

        // Delegates to the renderer — shape logic and render logic stay separate
        public override void Draw()
        {
            _renderer.Render("Circle");
        }
    }
}
