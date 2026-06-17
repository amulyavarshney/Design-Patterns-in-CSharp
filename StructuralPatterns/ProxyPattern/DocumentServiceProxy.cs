namespace ProxyPattern
{
    // Protection proxy — controls access to the real service based on user role
    public class DocumentServiceProxy : IDocumentService
    {
        // The real service — created lazily on first authorised access
        private RealDocumentService? _realService;

        // The current user's role
        private string _userRole;

        public DocumentServiceProxy(string userRole)
        {
            _userRole = userRole;
        }

        // Check access before forwarding to the real service
        public string GetDocument(string name)
        {
            if (_userRole != "Admin" && _userRole != "Editor")
            {
                return $"Access denied for role '{_userRole}'";
            }

            // Lazy initialisation — real service created only when first needed
            _realService ??= new RealDocumentService();

            Console.WriteLine($"Proxy: access granted for role '{_userRole}'");
            return _realService.GetDocument(name);
        }
    }
}
