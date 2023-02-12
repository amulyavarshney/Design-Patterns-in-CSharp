namespace MementoPattern
{
    // Main program class
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the Editor class
            var editor = new Editor();
            // Create an instance of the History class
            var history = new History();

            // Set the content of the editor
            editor.Content = "a";
            // Create a snapshot of the current content and add it to the history
            history.Push(editor.CreateState());
            // Update the content of the editor
            editor.Content = "b";
            // Create a snapshot of the current content and add it to the history
            history.Push(editor.CreateState());
            // Update the content of the editor
            editor.Content = "c";
            // Restore the previous state from the history
            editor.restore(history.Pop());

            // Display the current content of the editor
            Console.WriteLine(editor.Content); // a
        }
    }
}