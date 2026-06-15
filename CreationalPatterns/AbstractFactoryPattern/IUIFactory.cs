namespace AbstractFactoryPattern
{
    // Abstract factory — declares creation methods for each product in the family
    public interface IUIFactory
    {
        // Create a button belonging to this theme
        IButton CreateButton();

        // Create a checkbox belonging to this theme
        ICheckbox CreateCheckbox();
    }
}
