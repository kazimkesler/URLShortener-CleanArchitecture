using Application.Exceptions.Models;
using System.Net;

namespace WebAPI.HttpProblemDetails
{
    public class ValidationProblemDetails : BaseHttpProblemDetails
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; set; } = [];
        public ValidationProblemDetails(string detail, IEnumerable<ValidationExceptionModel> errors)
        {
            Type = "validation-error";
            StatusCode = (int)HttpStatusCode.BadRequest;
            Detail = detail;
            Errors = errors;
        }
    }
}
