using MTNMOMOApiIntegration.Database;
using MTNMOMOApiIntegration.ResponseModel;

namespace MTNMOMOApiIntegration.Repository
{
    public class MtnMomoApiRepository: IMtnMomoApiRepository
    {
        private readonly MtnMomoApiDataContext _mtnMomoApiDataContext;

        public MtnMomoApiRepository(MtnMomoApiDataContext mtnMomoApiDataContext)
        {
            _mtnMomoApiDataContext = mtnMomoApiDataContext;
        }

        public Request SaveRequest(Request request)
        {
            _mtnMomoApiDataContext.Request.Add(request);
            _mtnMomoApiDataContext.SaveChanges();

            return request;
        }

        public Response SaveResponse(Response response)
        {
            _mtnMomoApiDataContext.Response.Add(response);
            _mtnMomoApiDataContext.SaveChanges();

            return response;
        }
    }
}
