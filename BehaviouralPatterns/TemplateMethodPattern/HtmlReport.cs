namespace TemplateMethodPattern
{
    // Concrete class — generates a report in HTML format
    public class HtmlReport : ReportGenerator
    {
        // Override the formatting step to produce HTML output
        protected override void FormatData()
        {
            Console.WriteLine("Formatting data as HTML: <table><tr><td>id</td><td>name</td><td>value</td></tr></table>");
        }
    }
}
