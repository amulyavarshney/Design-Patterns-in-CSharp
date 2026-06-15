namespace AbstractFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Render with dark theme — client code never mentions DarkButton or DarkCheckbox
            Console.WriteLine("--- Dark Theme ---");
            var darkApp = new Application(new DarkThemeFactory());
            darkApp.RenderUI();

            Console.WriteLine();

            // Swap the entire family to light theme with one line
            Console.WriteLine("--- Light Theme ---");
            var lightApp = new Application(new LightThemeFactory());
            lightApp.RenderUI();
        }
    }
}
