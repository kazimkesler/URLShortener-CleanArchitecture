namespace WebApp.Contracts.Errors
{
    public class ErrorResponse
    {
        public int? StatusCode { get; protected set; }
        public string? Type { get; protected set; }
        public string? Detail { get; set; }
        public IEnumerable<ValidationModel> Errors { get; set; } = [];
    }

    public class ValidationModel
    {
        public string Property { get; set; }
        public IEnumerable<string> Errors { get; set; } = [];
    }
}
