namespace ProxyPattern
{
    // Subject interface — implemented by both the real service and the proxy
    public interface IDocumentService
    {
        string GetDocument(string name);
    }
}
