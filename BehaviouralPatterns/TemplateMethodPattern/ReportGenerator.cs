namespace TemplateMethodPattern
{
    // Abstract class that defines the template method and skeleton steps
    public abstract class ReportGenerator
    {
        // Template method — defines the fixed sequence of steps for every report
        // Marked sealed so subclasses cannot alter the overall algorithm
        public sealed void GenerateReport()
        {
            OpenFile();
            FetchData();
            FormatData();
            CloseFile();
        }

        // Shared step — same for all report types
        private void OpenFile()
        {
            Console.WriteLine("Opening file for writing");
        }

        // Shared step — same for all report types
        private void FetchData()
        {
            Console.WriteLine("Fetching data from database");
        }

        // Hook — subclasses provide their own formatting logic
        protected abstract void FormatData();

        // Shared step — same for all report types
        private void CloseFile()
        {
            Console.WriteLine("Closing file");
        }
    }
}
