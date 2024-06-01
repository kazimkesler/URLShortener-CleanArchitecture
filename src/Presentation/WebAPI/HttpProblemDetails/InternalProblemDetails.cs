using System.Net;

namespace WebAPI.HttpProblemDetails
{
    public class InternalProblemDetails : BaseHttpProblemDetails
    {
        public InternalProblemDetails()
        {
            Type = "internal-server-error";
            StatusCode = (int)HttpStatusCode.InternalServerError;
            Detail = "An unhandled error occurred";
        }
    }
}
