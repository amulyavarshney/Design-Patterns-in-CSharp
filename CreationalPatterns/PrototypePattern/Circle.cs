namespace PrototypePattern
{
    // Concrete prototype — a circle that can clone itself
    public class Circle : IShape
    {
        public int    X      { get; set; }
        public int    Y      { get; set; }
        public int    Radius { get; set; }
        public string Color  { get; set; }

        // Constructor to set all fields
        public Circle(int x, int y, int radius, string color)
        {
            X      = x;
            Y      = y;
            Radius = radius;
            Color  = color;
        }

        // Clone by creating a new Circle with the same field values
        public IShape Clone()
        {
            return new Circle(X, Y, Radius, Color);
        }

        // Display the circle's properties
        public void Draw()
        {
            Console.WriteLine($"Circle  — X:{X} Y:{Y} Radius:{Radius} Color:{Color}");
        }
    }
}
