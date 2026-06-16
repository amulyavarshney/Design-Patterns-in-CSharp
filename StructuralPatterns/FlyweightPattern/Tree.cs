namespace FlyweightPattern
{
    // Context — stores extrinsic (unique) state and a reference to the flyweight
    public class Tree
    {
        // Extrinsic state — unique to each tree instance
        private int      _x;
        private int      _y;

        // Shared flyweight — not duplicated across trees of the same type
        private TreeType _treeType;

        public Tree(int x, int y, TreeType treeType)
        {
            _x        = x;
            _y        = y;
            _treeType = treeType;
        }

        // Delegates rendering to the flyweight, passing extrinsic state
        public void Draw()
        {
            _treeType.Draw(_x, _y);
        }
    }
}
