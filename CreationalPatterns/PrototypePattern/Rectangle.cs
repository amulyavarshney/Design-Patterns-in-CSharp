namespace PrototypePattern
{
    // Concrete prototype — a rectangle that can clone itself
    public class Rectangle : IShape
    {
        public int    X      { get; set; }
        public int    Y      { get; set; }
        public int    Width  { get; set; }
        public int    Height { get; set; }
        public string Color  { get; set; }

        // Constructor to set all fields
        public Rectangle(int x, int y, int width, int height, string color)
        {
            X      = x;
            Y      = y;
            Width  = width;
            Height = height;
            Color  = color;
        }

        // Clone by creating a new Rectangle with the same field values
        public IShape Clone()
        {
            return new Rectangle(X, Y, Width, Height, Color);
        }

        // Display the rectangle's properties
        public void Draw()
        {
            Console.WriteLine($"Rectangle — X:{X} Y:{Y} Width:{Width} Height:{Height} Color:{Color}");
        }
    }
}
