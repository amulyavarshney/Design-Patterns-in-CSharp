namespace StatePattern
{
    // Program class to test the different tool types
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new canvas object
            var canvas = new Canvas();

            // Set the current tool to BrushTool
            canvas.currentTool = new BrushTool();

            // Call the MouseDown method of the canvas
            canvas.MouseDown();

            // Call the MouseUp method of the canvas
            canvas.MouseUp();
        }
    }
}
