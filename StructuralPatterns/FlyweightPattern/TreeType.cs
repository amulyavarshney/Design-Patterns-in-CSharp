namespace FlyweightPattern
{
    // Flyweight — stores intrinsic (shared) state that is identical across many trees
    public class TreeType
    {
        // Intrinsic state — shared and immutable
        public string Name    { get; }
        public string Colour  { get; }
        public string Texture { get; }

        public TreeType(string name, string colour, string texture)
        {
            Name    = name;
            Colour  = colour;
            Texture = texture;
        }

        // Draw uses intrinsic state from this object plus extrinsic state passed in
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing {Name} tree (colour:{Colour}) at ({x},{y})");
        }
    }
}
