using System.Text.Json;
using WebAPI.HttpProblemDetails;

namespace WebAPI.Extensions
{
    public static class ProblemDetailsExtensions
    {
        public static string ToJson<TProblemDetails>(this TProblemDetails problemDetails) where TProblemDetails : BaseHttpProblemDetails
            => JsonSerializer.Serialize(problemDetails, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
    }
}
