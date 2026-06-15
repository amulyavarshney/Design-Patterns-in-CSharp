namespace VisitorPattern
{
    // Concrete element — represents a document heading
    public class Heading : IDocumentElement
    {
        // The heading text
        public string Text { get; }

        // Constructor to set the heading text
        public Heading(string text)
        {
            Text = text;
        }

        // Accept the visitor and call the correct overload for this element type
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
