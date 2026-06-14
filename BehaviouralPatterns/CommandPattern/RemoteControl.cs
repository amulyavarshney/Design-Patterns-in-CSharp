namespace CommandPattern
{
    // The Invoker — triggers commands without knowing what they do
    public class RemoteControl
    {
        // The last command executed, kept for undo support
        private ICommand? _lastCommand;

        // Execute a command and remember it for undo
        public void PressButton(ICommand command)
        {
            command.Execute();
            _lastCommand = command;
        }

        // Undo the last executed command
        public void PressUndo()
        {
            if (_lastCommand != null)
                _lastCommand.Undo();
            else
                Console.WriteLine("Nothing to undo");
        }
    }
}
