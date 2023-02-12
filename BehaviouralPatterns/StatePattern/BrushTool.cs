namespace StatePattern
{
    // Concrete implementation of the BrushTool tool type
    public class BrushTool : ToolType
    {
        // Override method for handling mouse down events
        public override void MouseDown()
        {
            Console.WriteLine("Brush icon");
        }

        // Override method for handling mouse up events
        public override void MouseUp()
        {
            Console.WriteLine("Draw a line");
        }
    }
}
