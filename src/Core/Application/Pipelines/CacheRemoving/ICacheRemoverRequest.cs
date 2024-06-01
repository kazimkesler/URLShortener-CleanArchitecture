namespace Application.Pipelines.CacheRemoving
{
    public interface ICacheRemoverRequest
    {
        string CacheKey { get; }
    }
}
