namespace VisitorPattern
{
    // Interface that all visitors must implement — one overload per element type
    public interface IVisitor
    {
        // Visit a Heading element
        void Visit(Heading heading);

        // Visit a Paragraph element
        void Visit(Paragraph paragraph);
    }
}
