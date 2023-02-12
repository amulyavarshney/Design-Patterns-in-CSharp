namespace MementoPattern
{
    // Class Editor which stores the current content of an editor
    class Editor
    {
        // Content property to store the current content of the editor
        public string Content { get; set; }

        // CreateState method to create a snapshot of the current content of the editor
        public EditorState CreateState()
        {
            return new EditorState(Content);
        }

        // Restore method to restore the previous content of the editor
        public void restore(EditorState state)
        {
            Content = state.Content;
        }
    }
}
