namespace AbstractFactoryPattern
{
    // Concrete product — dark-theme checkbox
    public class DarkCheckbox : ICheckbox
    {
        public void Render()
        {
            Console.WriteLine("Rendering Dark Checkbox");
        }
    }
}
