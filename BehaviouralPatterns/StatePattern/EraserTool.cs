namespace StatePattern
{
    // Concrete implementation of the EraserTool tool type
    public class EraserTool : ToolType
    {
        // Override method for handling mouse down events
        public override void MouseDown()
        {
            Console.WriteLine("Eraser icon");
        }

        // Override method for handling mouse up events
        public override void MouseUp()
        {
            Console.WriteLine("Erase Something");
        }
    }
}
