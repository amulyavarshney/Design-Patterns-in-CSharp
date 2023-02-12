namespace StatePattern
{
    // Abstract class representing the different tool types
    public abstract class ToolType
    {
        // Abstract method for handling mouse down events
        public abstract void MouseDown();

        // Abstract method for handling mouse up events
        public abstract void MouseUp();
    }

    // An interface can be craeted instead of an abstract class
    /*public interface IToolType
    {
        public void MouseDown();
        public void MouseUp();
    }*/
}
