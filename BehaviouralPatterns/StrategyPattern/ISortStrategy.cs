namespace StrategyPattern
{
    // Interface that all sorting strategies must implement
    public interface ISortStrategy
    {
        // Sort the given list in place
        void Sort(List<int> data);
    }
}
