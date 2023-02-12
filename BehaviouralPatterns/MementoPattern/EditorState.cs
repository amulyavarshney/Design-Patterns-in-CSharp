namespace MementoPattern
{
    // Class EditorState which stores the snapshot of the current content of the editor
    class EditorState
    {
        // Content property to store the snapshot of the current content
        public string Content { get; }

        // Constructor to initialize the Content property
        public EditorState(string content)
        {
            Content = content;
        }
    }
}
