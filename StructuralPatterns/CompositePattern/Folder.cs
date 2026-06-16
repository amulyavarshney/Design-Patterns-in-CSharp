namespace CompositePattern
{
    // Composite — can contain files and other folders
    public class Folder : IFileSystemItem
    {
        private string _name;

        // Children can be leaves (files) or other composites (folders)
        private List<IFileSystemItem> _children = new List<IFileSystemItem>();

        public Folder(string name)
        {
            _name = name;
        }

        // Add any component — client treats files and folders uniformly
        public void Add(IFileSystemItem item)
        {
            _children.Add(item);
        }

        // Display this folder then recursively display all children
        public void Display(string indent)
        {
            Console.WriteLine($"{indent}+ {_name}");
            foreach (var child in _children)
                child.Display(indent + "  ");
        }
    }
}
