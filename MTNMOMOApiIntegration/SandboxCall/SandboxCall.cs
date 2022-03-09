using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace MTNMOMOApiIntegration.SandboxCall
{
    public class SandboxCall
    {
        private readonly string apiUrl = "https://sandbox.momodeveloper.mtn.com";

        public async Task<HttpResponseMessage> CallSandBox(RequestModel.RequestModel requestModel, HttpMethod httpMethod)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            if (!string.IsNullOrEmpty(requestModel.XReferenceId))
            {
                client.DefaultRequestHeaders.Add("X-Reference-Id", requestModel.XReferenceId);
            }

            if (!string.IsNullOrEmpty(requestModel.OcpApimSubscriptionKey))
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", requestModel.OcpApimSubscriptionKey);
            }

            if (!string.IsNullOrEmpty(requestModel.XTargetEnvironment))
            {
                client.DefaultRequestHeaders.Add("X-Target-Environment", requestModel.XTargetEnvironment);
            }

            if (!string.IsNullOrEmpty(requestModel.AuthenticationType))
            {
                if (requestModel.AuthenticationType == "Basic")
                {
                    client.DefaultRequestHeaders.Add("Authorization", requestModel.AuthenticationType + " " + this.Base64Encode(requestModel.AuthenticationUserName + ":" + requestModel.AuthenticationPassword));
                }

                if (requestModel.AuthenticationType == "Bearer")
                {
                    client.DefaultRequestHeaders.Add("Authorization", requestModel.AuthenticationType + " " + requestModel.Token);
                }

            }

            var uri = apiUrl + requestModel.apiUrl;

            HttpResponseMessage response = null;

            string jsonString = JsonSerializer.Serialize(requestModel);

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes(jsonString);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                if (httpMethod == HttpMethod.Post)
                {
                    response = await client.PostAsync(uri, content);
                }

                if (httpMethod == HttpMethod.Get)
                {
                    response = await client.GetAsync(uri);
                }
            }

            return response;
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
