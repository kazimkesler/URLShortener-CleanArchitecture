using System.Net;

namespace WebAPI.HttpProblemDetails
{
    public class BusinessProblemDetails : BaseHttpProblemDetails
    {
        public BusinessProblemDetails(string detail)
        {
            Type = "business-error";
            StatusCode = (int)HttpStatusCode.BadRequest;
            Detail = detail;
        }
    }
}
