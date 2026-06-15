namespace AbstractFactoryPattern
{
    // Concrete factory — produces the light-theme family of widgets
    public class LightThemeFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new LightButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new LightCheckbox();
        }
    }
}
