using System.Runtime.InteropServices;

namespace MTNMOMOApiIntegration.RequestModel
{
    public class RequestModel
    {
        public string? XReferenceId { get; set; }
        public string? OcpApimSubscriptionKey { get; set; }
        public string? providerCallbackHost { get; set; }
        public string? ApiKey { get; set; }
        public string? apiUrl { get; set; }
        public string? AuthenticationType { get; set; }
        public string? AuthenticationUserName { get; set; }
        public string? AuthenticationPassword { get; set; }
        public string? Token { get; set; }

        public RequestModel()
        {
            OcpApimSubscriptionKey = "a8e35d380d354caa9e1d23344a204e3c";
        }
    }
}
