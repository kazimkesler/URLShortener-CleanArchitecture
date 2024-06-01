namespace Application.Exceptions.Models
{
    public abstract class ProblemDetails
    {
        public string Type { get; protected set; }
        public string Detail { get; set; }
    }
}
