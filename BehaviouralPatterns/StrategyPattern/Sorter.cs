namespace StrategyPattern
{
    // The Context — delegates sorting work to whichever strategy is assigned
    class Sorter
    {
        // The current sorting strategy
        public ISortStrategy Strategy { get; set; }

        // Constructor to set the initial strategy
        public Sorter(ISortStrategy strategy)
        {
            Strategy = strategy;
        }

        // Sort the data using the current strategy
        public void Sort(List<int> data)
        {
            Strategy.Sort(data);
        }
    }
}
