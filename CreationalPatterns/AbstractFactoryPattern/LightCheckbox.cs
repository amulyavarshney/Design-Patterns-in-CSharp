namespace AbstractFactoryPattern
{
    // Concrete product — light-theme checkbox
    public class LightCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Light Checkbox");
        }
    }
}
