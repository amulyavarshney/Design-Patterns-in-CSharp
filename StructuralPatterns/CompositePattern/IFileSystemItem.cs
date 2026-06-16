namespace CompositePattern
{
    // Component — common interface for both leaves and composites
    public interface IFileSystemItem
    {
        // Display the item, indented to show tree depth
        void Display(string indent);
    }
}
