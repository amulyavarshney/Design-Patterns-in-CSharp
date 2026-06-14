namespace CommandPattern
{
    // Program class to demonstrate the Command pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Receiver
            var livingRoomLight = new Light("Living Room");

            // Concrete commands bound to the receiver
            var lightOn  = new LightOnCommand(livingRoomLight);
            var lightOff = new LightOffCommand(livingRoomLight);

            // Invoker
            var remote = new RemoteControl();

            // Press ON — executes the command
            remote.PressButton(lightOn);

            // Press UNDO — reverses the last command
            remote.PressUndo();

            // Press OFF — executes the command
            remote.PressButton(lightOff);

            // Press UNDO — reverses the last command
            remote.PressUndo();
        }
    }
}
