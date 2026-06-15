namespace VisitorPattern
{
    // Concrete visitor — exports document elements as Markdown
    public class MarkdownExporter : IVisitor
    {
        // Render a heading as a Markdown # heading
        public void Visit(Heading heading)
        {
            Console.WriteLine($"# {heading.Text}");
        }

        // Render a paragraph as plain Markdown text
        public void Visit(Paragraph paragraph)
        {
            Console.WriteLine(paragraph.Text);
        }
    }
}
