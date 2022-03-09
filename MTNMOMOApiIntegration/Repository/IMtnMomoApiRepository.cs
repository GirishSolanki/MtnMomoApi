using MTNMOMOApiIntegration.ResponseModel;

namespace MTNMOMOApiIntegration.Repository
{
    public interface IMtnMomoApiRepository
    {
        Request SaveRequest(Request request);
        Response SaveResponse(Response response);
    }
}
