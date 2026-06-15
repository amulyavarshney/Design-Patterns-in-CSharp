namespace VisitorPattern
{
    // Interface that all document elements must implement
    public interface IDocumentElement
    {
        // Accept a visitor and let it operate on this element
        void Accept(IVisitor visitor);
    }
}
