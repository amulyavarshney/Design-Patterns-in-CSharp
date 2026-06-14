namespace CommandPattern
{
    // The Receiver — knows how to carry out the actual work
    public class Light
    {
        // Name of the light so output messages are descriptive
        private string _name;

        // Constructor to set the light's name
        public Light(string name)
        {
            _name = name;
        }

        // Turn the light on
        public void TurnOn()
        {
            Console.WriteLine($"{_name} light is ON");
        }

        // Turn the light off
        public void TurnOff()
        {
            Console.WriteLine($"{_name} light is OFF");
        }
    }
}
