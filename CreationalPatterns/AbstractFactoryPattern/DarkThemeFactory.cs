namespace AbstractFactoryPattern
{
    // Concrete factory — produces the dark-theme family of widgets
    public class DarkThemeFactory : IUIFactory
    {
        public IButton CreateButton()
        {
            return new DarkButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new DarkCheckbox();
        }
    }
}
