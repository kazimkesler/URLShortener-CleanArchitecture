using System.Net;

namespace WebAPI.HttpProblemDetails
{
    public class ForbiddenProblemDetails : BaseHttpProblemDetails
    {
        public ForbiddenProblemDetails(string detail)
        {
            Type = "forbidden-error";
            StatusCode = (int)HttpStatusCode.Forbidden;
            Detail = detail;
        }
    }
}
