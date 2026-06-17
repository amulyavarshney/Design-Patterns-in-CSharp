namespace ProxyPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // All clients use the same IDocumentService interface
            IDocumentService adminProxy  = new DocumentServiceProxy("Admin");
            IDocumentService editorProxy = new DocumentServiceProxy("Editor");
            IDocumentService guestProxy  = new DocumentServiceProxy("Guest");

            Console.WriteLine(adminProxy.GetDocument("annual-report.pdf"));
            Console.WriteLine();
            Console.WriteLine(editorProxy.GetDocument("draft.docx"));
            Console.WriteLine();
            Console.WriteLine(guestProxy.GetDocument("confidential.pdf"));
        }
    }
}
