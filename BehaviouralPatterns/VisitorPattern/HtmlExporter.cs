namespace VisitorPattern
{
    // Concrete visitor — exports document elements as HTML
    public class HtmlExporter : IVisitor
    {
        // Render a heading as an HTML <h1> tag
        public void Visit(Heading heading)
        {
            Console.WriteLine($"<h1>{heading.Text}</h1>");
        }

        // Render a paragraph as an HTML <p> tag
        public void Visit(Paragraph paragraph)
        {
            Console.WriteLine($"<p>{paragraph.Text}</p>");
        }
    }
}
