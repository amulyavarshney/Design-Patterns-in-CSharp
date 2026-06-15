namespace AbstractFactoryPattern
{
    // Client — uses the factory interface only, never references concrete types
    public class Application
    {
        private IButton   _button;
        private ICheckbox _checkbox;

        // Constructor receives any factory — products are always consistent
        public Application(IUIFactory factory)
        {
            _button   = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        // Render all widgets in the current theme
        public void RenderUI()
        {
            _button.Render();
            _checkbox.Render();
        }
    }
}
