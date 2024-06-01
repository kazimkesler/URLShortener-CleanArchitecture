using System.Net;

namespace WebAPI.HttpProblemDetails
{
    public class NotFoundProblemDetails : BaseHttpProblemDetails
    {
        public NotFoundProblemDetails(string detail)
        {
            Type = "not-found-error";
            StatusCode = (int)HttpStatusCode.NotFound;
            Detail = detail;
        }
    }
}
