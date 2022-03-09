using Microsoft.AspNetCore.Mvc;
using MTNMOMOApiIntegration.Repository;
using System.Text.Json;

namespace MTNMOMOApiIntegration.Controllers
{
    [Route("api")]
    [ApiController]
    public class MtnMomoApiController : ControllerBase
    {
        private readonly IMtnMomoApiRepository _mtnMomoApiRepository;

        public MtnMomoApiController(IMtnMomoApiRepository mtnMomoApiRepository)
        {
            this._mtnMomoApiRepository = mtnMomoApiRepository;
        }


        [HttpPost("create-api-user")]
        public IActionResult CreateApiUser(RequestModel.RequestModel requestModel)
        {
            requestModel.apiUrl = "/v1_0/apiuser";
            var request = this._mtnMomoApiRepository.SaveRequest(new ResponseModel.Request(JsonSerializer.Serialize(requestModel)));
            HttpResponseMessage httpResponseMessage = new SandboxCall.SandboxCall().CallSandBox(requestModel, HttpMethod.Post).Result;
            var genericResponse = new GenericResponse<dynamic>(httpResponseMessage.StatusCode.ToString(), httpResponseMessage.StatusCode.ToString(), httpResponseMessage.Content.ReadAsStringAsync().Result, httpResponseMessage.IsSuccessStatusCode);
            this._mtnMomoApiRepository.SaveResponse(new ResponseModel.Response(request.RequestId, JsonSerializer.Serialize(genericResponse)));
            return Ok(genericResponse);
        }

        [HttpPost("get-api-user")]
        public IActionResult GetApiUser(RequestModel.RequestModel requestModel)
        {
            requestModel.apiUrl = "/v1_0/apiuser/" + requestModel.XReferenceId;
            requestModel.XReferenceId = null;
            var request = this._mtnMomoApiRepository.SaveRequest(new ResponseModel.Request(JsonSerializer.Serialize(requestModel)));
            HttpResponseMessage httpResponseMessage = new SandboxCall.SandboxCall().CallSandBox(requestModel, HttpMethod.Get).Result;
            var genericResponse = new GenericResponse<dynamic>(httpResponseMessage.StatusCode.ToString(), httpResponseMessage.StatusCode.ToString(), httpResponseMessage.Content.ReadAsStringAsync().Result, httpResponseMessage.IsSuccessStatusCode);
            this._mtnMomoApiRepository.SaveResponse(new ResponseModel.Response(request.RequestId, JsonSerializer.Serialize(genericResponse)));
            return Ok(genericResponse);
        }

        [HttpPost("get-api-key")]
        public IActionResult GetApiKey(RequestModel.RequestModel requestModel)
        {
            requestModel.apiUrl = "/v1_0/apiuser/" + requestModel.XReferenceId + "/apikey";
            requestModel.XReferenceId = null;
            var request = this._mtnMomoApiRepository.SaveRequest(new ResponseModel.Request(JsonSerializer.Serialize(requestModel)));
            HttpResponseMessage httpResponseMessage = new SandboxCall.SandboxCall().CallSandBox(requestModel, HttpMethod.Post).Result;
            var genericResponse = new GenericResponse<dynamic>(httpResponseMessage.StatusCode.ToString(), httpResponseMessage.StatusCode.ToString(), httpResponseMessage.Content.ReadAsStringAsync().Result, httpResponseMessage.IsSuccessStatusCode);
            this._mtnMomoApiRepository.SaveResponse(new ResponseModel.Response(request.RequestId, JsonSerializer.Serialize(genericResponse)));
            return Ok(genericResponse);

        }

        [HttpPost("get-token")]
        public IActionResult GetApiToken(RequestModel.RequestModel requestModel)
        {
            requestModel.apiUrl = "/collection/token/";
            requestModel.XReferenceId = null;
            requestModel.AuthenticationType = "Basic";
            var request = this._mtnMomoApiRepository.SaveRequest(new ResponseModel.Request(JsonSerializer.Serialize(requestModel)));
            HttpResponseMessage httpResponseMessage = new SandboxCall.SandboxCall().CallSandBox(requestModel, HttpMethod.Post).Result;
            var genericResponse = new GenericResponse<dynamic>(httpResponseMessage.StatusCode.ToString(), httpResponseMessage.StatusCode.ToString(), httpResponseMessage.Content.ReadAsStringAsync().Result, httpResponseMessage.IsSuccessStatusCode);
            this._mtnMomoApiRepository.SaveResponse(new ResponseModel.Response(request.RequestId, JsonSerializer.Serialize(genericResponse)));
            return Ok(genericResponse);
        }

        [HttpPost("request-to-pay")]
        public IActionResult RequestToPay(RequestModel.RequestModel requestModel)
        {
            requestModel.apiUrl = "/collection/v1_0/requesttopay";
            requestModel.AuthenticationType = "Bearer";
            requestModel.currency = "EUR";
            requestModel.externalId = new Random().Next().ToString();
            var request = this._mtnMomoApiRepository.SaveRequest(new ResponseModel.Request(JsonSerializer.Serialize(requestModel)));
            HttpResponseMessage httpResponseMessage = new SandboxCall.SandboxCall().CallSandBox(requestModel, HttpMethod.Post).Result;
            var genericResponse = new GenericResponse<dynamic>(httpResponseMessage.StatusCode.ToString(), httpResponseMessage.StatusCode.ToString(), httpResponseMessage.Content.ReadAsStringAsync().Result, httpResponseMessage.IsSuccessStatusCode);
            this._mtnMomoApiRepository.SaveResponse(new ResponseModel.Response(request.RequestId, JsonSerializer.Serialize(genericResponse)));
            return Ok(genericResponse);
        }
    }
}
