namespace FacadePattern
{
    // Subsystem class — controls the projector
    public class Projector
    {
        public void On()         => Console.WriteLine("Projector: turning on");
        public void Off()        => Console.WriteLine("Projector: turning off");
        public void WideScreen() => Console.WriteLine("Projector: widescreen mode on");
    }
}
