namespace CommandPattern
{
    // Concrete command — turns a light off
    public class LightOffCommand : ICommand
    {
        // Reference to the receiver that does the actual work
        private Light _light;

        // Constructor binds this command to a specific light
        public LightOffCommand(Light light)
        {
            _light = light;
        }

        // Execute turns the light off
        public void Execute()
        {
            _light.TurnOff();
        }

        // Undo reverses the action by turning the light on
        public void Undo()
        {
            _light.TurnOn();
        }
    }
}
