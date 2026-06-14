namespace CommandPattern
{
    // Interface that all commands must implement
    public interface ICommand
    {
        // Execute the command
        void Execute();

        // Undo the command
        void Undo();
    }
}
