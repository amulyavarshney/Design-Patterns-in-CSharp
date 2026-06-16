namespace CompositePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build a tree: root → src, docs; src → main.cs, utils.cs; docs → readme.md
            var root = new Folder("root");

            var src = new Folder("src");
            src.Add(new File("main.cs"));
            src.Add(new File("utils.cs"));

            var docs = new Folder("docs");
            docs.Add(new File("readme.md"));

            root.Add(src);
            root.Add(docs);
            root.Add(new File("config.json"));

            // Display the whole tree — client calls Display on root only
            root.Display("");
        }
    }
}
