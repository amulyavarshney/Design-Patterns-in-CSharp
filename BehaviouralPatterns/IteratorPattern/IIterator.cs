namespace IteratorPattern
{
    // Interface that all iterators must implement
    public interface IIterator
    {
        // Returns true if there are more elements to iterate over
        bool HasNext();

        // Returns the next element and advances the position
        string Next();
    }
}
