namespace TemplateMethodPattern
{
    // Program class to demonstrate the Template Method pattern
    internal class Program
    {
        static void Main(string[] args)
        {
            // Generate a CSV report — steps are fixed, only formatting differs
            Console.WriteLine("--- Generating CSV Report ---");
            ReportGenerator csvReport = new CsvReport();
            csvReport.GenerateReport();

            Console.WriteLine();

            // Generate an HTML report — same steps, different formatting
            Console.WriteLine("--- Generating HTML Report ---");
            ReportGenerator htmlReport = new HtmlReport();
            htmlReport.GenerateReport();
        }
    }
}
