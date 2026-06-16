namespace CompositePattern
{
    // Leaf — has no children, represents a single file
    public class File : IFileSystemItem
    {
        private string _name;

        public File(string name)
        {
            _name = name;
        }

        // A leaf simply displays itself
        public void Display(string indent)
        {
            Console.WriteLine($"{indent}- {_name}");
        }
    }
}
