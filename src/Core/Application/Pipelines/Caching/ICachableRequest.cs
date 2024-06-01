namespace Application.Pipelines.Caching
{
    public interface ICachableRequest
    {
        string CacheKey { get; }
    }
}
