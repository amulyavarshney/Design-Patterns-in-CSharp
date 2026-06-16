namespace FlyweightPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new TreeTypeFactory();
            var trees   = new List<Tree>();

            // Plant 6 trees of only 2 unique types — factory creates each type once
            trees.Add(new Tree(1,  1,  factory.GetTreeType("Oak",  "Green", "rough")));
            trees.Add(new Tree(3,  7,  factory.GetTreeType("Oak",  "Green", "rough")));
            trees.Add(new Tree(5,  2,  factory.GetTreeType("Oak",  "Green", "rough")));
            trees.Add(new Tree(2,  9,  factory.GetTreeType("Pine", "DarkGreen", "smooth")));
            trees.Add(new Tree(8,  4,  factory.GetTreeType("Pine", "DarkGreen", "smooth")));
            trees.Add(new Tree(6,  6,  factory.GetTreeType("Pine", "DarkGreen", "smooth")));

            Console.WriteLine();
            Console.WriteLine($"Trees planted: {trees.Count}  |  Unique TreeType objects: {factory.Count}");
            Console.WriteLine();

            foreach (var tree in trees)
                tree.Draw();
        }
    }
}
