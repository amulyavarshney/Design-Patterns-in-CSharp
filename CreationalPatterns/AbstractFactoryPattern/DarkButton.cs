namespace AbstractFactoryPattern
{
    // Concrete product — dark-theme button
    public class DarkButton : IButton
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Button");
        }
    }
}
