namespace BridgePattern
{
    // Implementation interface — the bridge between shapes and renderers
    public interface IRenderer
    {
        // Render the given shape name using this renderer's technique
        void Render(string shapeName);
    }
}
