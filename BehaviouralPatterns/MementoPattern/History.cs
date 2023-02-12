namespace MementoPattern
{
    // Class History to store the history of changes made to the editor's content
    class History
    {
        // States list to store the history of changes
        public List<EditorState> states = new List<EditorState>();

        // Push method to add a snapshot to the history
        public void Push(EditorState state)
        {
            states.Add(state);
        }

        // Pop method to restore the previous state from the history
        public EditorState Pop()
        {
            var lastIndex = states.Count - 1;
            var lastState = states[lastIndex];
            states.Remove(lastState);

            return lastState;
        }
    }
}
