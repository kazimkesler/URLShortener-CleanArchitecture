using System.Net;

namespace WebAPI.HttpProblemDetails
{
    public class UnauthorizedProblemDetails : BaseHttpProblemDetails
    {
        public UnauthorizedProblemDetails(string detail)
        {
            Type = "unauthorized-error";
            StatusCode = (int)HttpStatusCode.Unauthorized;
            Detail = detail;
        }
    }
}
