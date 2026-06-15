namespace AbstractFactoryPattern
{
    // Concrete product — light-theme button
    public class LightButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Button");
        }
    }
}
