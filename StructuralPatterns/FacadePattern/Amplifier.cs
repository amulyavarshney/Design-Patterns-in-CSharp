namespace FacadePattern
{
    // Subsystem class — controls the amplifier
    public class Amplifier
    {
        public void On()     => Console.WriteLine("Amplifier: turning on");
        public void Off()    => Console.WriteLine("Amplifier: turning off");
        public void SetVolume(int level) => Console.WriteLine($"Amplifier: volume set to {level}");
    }
}
