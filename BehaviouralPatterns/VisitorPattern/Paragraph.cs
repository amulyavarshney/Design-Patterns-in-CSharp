namespace VisitorPattern
{
    // Concrete element — represents a document paragraph
    public class Paragraph : IDocumentElement
    {
        // The paragraph text
        public string Text { get; }

        // Constructor to set the paragraph text
        public Paragraph(string text)
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
