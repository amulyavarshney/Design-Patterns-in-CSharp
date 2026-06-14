namespace StrategyPattern
{
    // Program class to demonstrate the Strategy pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a sorter with Bubble Sort as the initial strategy
            var sorter = new Sorter(new BubbleSort());

            var data = new List<int> { 5, 3, 8, 1, 9, 2 };
            sorter.Sort(data);
            Console.WriteLine(string.Join(", ", data)); // 1, 2, 3, 5, 8, 9

            // Swap strategy to Quick Sort at runtime — no change to Sorter code
            sorter.Strategy = new QuickSort();

            data = new List<int> { 7, 4, 6, 2, 1, 8 };
            sorter.Sort(data);
            Console.WriteLine(string.Join(", ", data)); // 1, 2, 4, 6, 7, 8

            // Swap strategy to Merge Sort
            sorter.Strategy = new MergeSort();

            data = new List<int> { 10, 3, 7, 5, 2, 9 };
            sorter.Sort(data);
            Console.WriteLine(string.Join(", ", data)); // 2, 3, 5, 7, 9, 10
        }
    }
}
