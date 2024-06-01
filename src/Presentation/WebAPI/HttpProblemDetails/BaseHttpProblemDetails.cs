using Application.Exceptions.Models;

namespace WebAPI.HttpProblemDetails
{
    public abstract class BaseHttpProblemDetails : ProblemDetails
    {
        public int StatusCode { get; protected set; }
    }
}
