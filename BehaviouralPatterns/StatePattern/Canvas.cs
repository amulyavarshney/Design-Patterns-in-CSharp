namespace StatePattern
{
    // The canvas class which contains the current tool used
    class Canvas
    {
        // Property for holding the current tool
        public ToolType currentTool { get; set; }

        // Method for handling mouse down events
        public void MouseDown()
        {
            // Call the MouseDown method of the current tool
            currentTool.MouseDown();
        }

        // Method for handling mouse up events
        public void MouseUp()
        {
            // Call the MouseUp method of the current tool
            currentTool.MouseUp();
        }
    }
}
