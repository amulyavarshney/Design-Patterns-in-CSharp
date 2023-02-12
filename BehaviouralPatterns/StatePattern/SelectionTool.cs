namespace StatePattern
{
    // Concrete implementation of the SelectionTool tool type
    public class SelectionTool : ToolType
    {
        // Override method for handling mouse down events
        public override void MouseDown()
        {
            Console.WriteLine("Selection icon");
        }

        // Override method for handling mouse up events
        public override void MouseUp()
        {
            Console.WriteLine("Draw a dashed rectangle");
        }
    }
}
