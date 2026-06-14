namespace CommandPattern
{
    // Concrete command — turns a light on
    public class LightOnCommand : ICommand
    {
        // Reference to the receiver that does the actual work
        private Light _light;

        // Constructor binds this command to a specific light
        public LightOnCommand(Light light)
        {
            _light = light;
        }

        // Execute turns the light on
        public void Execute()
        {
            _light.TurnOn();
        }

        // Undo reverses the action by turning the light off
        public void Undo()
        {
            _light.TurnOff();
        }
    }
}
