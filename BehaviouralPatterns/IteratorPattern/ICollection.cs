namespace IteratorPattern
{
    // Interface that all iterable collections must implement
    public interface ICollection
    {
        // Returns an iterator for traversing the collection
        IIterator CreateIterator();
    }
}
