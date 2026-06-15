namespace PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Original shapes
            var circle    = new Circle(10, 20, 50, "Red");
            var rectangle = new Rectangle(5, 10, 100, 60, "Blue");

            // Clone them — no knowledge of their concrete type needed
            var circleClone    = circle.Clone();
            var rectangleClone = rectangle.Clone();

            Console.WriteLine("--- Originals ---");
            circle.Draw();
            rectangle.Draw();

            // Mutate the clones — originals must be unaffected
            ((Circle)circleClone).Color       = "Green";
            ((Rectangle)rectangleClone).Width = 200;

            Console.WriteLine();
            Console.WriteLine("--- Clones after mutation ---");
            circleClone.Draw();
            rectangleClone.Draw();

            Console.WriteLine();
            Console.WriteLine("--- Originals unchanged ---");
            circle.Draw();
            rectangle.Draw();
        }
    }
}
