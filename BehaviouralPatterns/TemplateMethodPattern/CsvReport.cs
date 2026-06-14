namespace TemplateMethodPattern
{
    // Concrete class — generates a report in CSV format
    public class CsvReport : ReportGenerator
    {
        // Override the formatting step to produce CSV output
        protected override void FormatData()
        {
            Console.WriteLine("Formatting data as CSV: id,name,value");
        }
    }
}
