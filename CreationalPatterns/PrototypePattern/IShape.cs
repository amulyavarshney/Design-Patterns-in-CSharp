namespace PrototypePattern
{
    // Interface that all cloneable shapes must implement
    public interface IShape
    {
        // Create and return a deep copy of this shape
        IShape Clone();

        // Display the shape's current properties
        void Draw();
    }
}
