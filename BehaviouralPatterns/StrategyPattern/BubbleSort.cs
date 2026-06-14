namespace StrategyPattern
{
    // Concrete strategy — sorts using the Bubble Sort algorithm
    public class BubbleSort : ISortStrategy
    {
        // Sort the list by repeatedly swapping adjacent out-of-order elements
        public void Sort(List<int> data)
        {
            Console.WriteLine("Sorting using Bubble Sort");

            for (int i = 0; i < data.Count - 1; i++)
            {
                for (int j = 0; j < data.Count - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }
    }
}
