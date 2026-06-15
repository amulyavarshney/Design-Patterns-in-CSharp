namespace VisitorPattern
{
    // Program class to demonstrate the Visitor pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Build a document made up of elements
            var document = new List<IDocumentElement>
            {
                new Heading("Design Patterns"),
                new Paragraph("Patterns are reusable solutions to common problems."),
                new Heading("Visitor Pattern"),
                new Paragraph("The visitor separates an algorithm from the objects it operates on.")
            };

            // Export the same document as HTML — no changes to the elements
            Console.WriteLine("--- HTML Export ---");
            var htmlExporter = new HtmlExporter();
            foreach (var element in document)
                element.Accept(htmlExporter);

            Console.WriteLine();

            // Export the same document as Markdown — no changes to the elements
            Console.WriteLine("--- Markdown Export ---");
            var markdownExporter = new MarkdownExporter();
            foreach (var element in document)
                element.Accept(markdownExporter);
        }
    }
}
