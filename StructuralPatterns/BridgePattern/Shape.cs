namespace BridgePattern
{
    // Abstraction — holds the bridge to the implementation
    public abstract class Shape
    {
        // The renderer is injected — shapes and renderers vary independently
        protected IRenderer _renderer;

        // Constructor receives any renderer implementation
        protected Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        // Each shape subclass defines how it draws itself
        public abstract void Draw();
    }
}
