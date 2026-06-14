namespace StrategyPattern
{
    // Concrete strategy — sorts using the Quick Sort algorithm
    public class QuickSort : ISortStrategy
    {
        // Sort the list by partitioning around a pivot
        public void Sort(List<int> data)
        {
            Console.WriteLine("Sorting using Quick Sort");
            QuickSortRecursive(data, 0, data.Count - 1);
        }

        private void QuickSortRecursive(List<int> data, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(data, low, high);
                QuickSortRecursive(data, low, pivotIndex - 1);
                QuickSortRecursive(data, pivotIndex + 1, high);
            }
        }

        private int Partition(List<int> data, int low, int high)
        {
            int pivot = data[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (data[j] <= pivot)
                {
                    i++;
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                }
            }

            int swap = data[i + 1];
            data[i + 1] = data[high];
            data[high] = swap;

            return i + 1;
        }
    }
}
