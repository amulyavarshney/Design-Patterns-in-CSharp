namespace ProxyPattern
{
    // Real subject — performs the actual work of retrieving documents
    public class RealDocumentService : IDocumentService
    {
        public string GetDocument(string name)
        {
            return $"[Document content of '{name}']";
        }
    }
}
