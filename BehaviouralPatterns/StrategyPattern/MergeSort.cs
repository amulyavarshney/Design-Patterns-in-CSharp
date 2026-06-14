namespace StrategyPattern
{
    // Concrete strategy — sorts using the Merge Sort algorithm
    public class MergeSort : ISortStrategy
    {
        // Sort the list by recursively splitting and merging halves
        public void Sort(List<int> data)
        {
            Console.WriteLine("Sorting using Merge Sort");
            MergeSortRecursive(data, 0, data.Count - 1);
        }

        private void MergeSortRecursive(List<int> data, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSortRecursive(data, left, mid);
                MergeSortRecursive(data, mid + 1, right);
                Merge(data, left, mid, right);
            }
        }

        private void Merge(List<int> data, int left, int mid, int right)
        {
            var leftPart  = data.GetRange(left, mid - left + 1);
            var rightPart = data.GetRange(mid + 1, right - mid);

            int i = 0, j = 0, k = left;

            while (i < leftPart.Count && j < rightPart.Count)
            {
                if (leftPart[i] <= rightPart[j])
                    data[k++] = leftPart[i++];
                else
                    data[k++] = rightPart[j++];
            }

            while (i < leftPart.Count)  data[k++] = leftPart[i++];
            while (j < rightPart.Count) data[k++] = rightPart[j++];
        }
    }
}
