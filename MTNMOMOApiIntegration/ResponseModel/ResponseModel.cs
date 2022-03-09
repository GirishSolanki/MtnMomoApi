using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTNMOMOApiIntegration.ResponseModel
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponseId { get; protected set; }
        public int? RequestId { get; protected set; }
        public string? ResponseResult { get; protected set; }

        public Response(int? requestId, string? responseResult)
        {
            this.RequestId = requestId;
            this.ResponseResult = responseResult;
        }

    }

    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; protected set; }

        public string? RequestParameter { get; protected set; }

        public Request(string? requestParameter)
        {
            this.RequestParameter = requestParameter;
        }
    }
}
