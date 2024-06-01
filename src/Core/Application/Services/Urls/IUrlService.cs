using Domain.Entities;

namespace Application.Services.Urls
{
    /// <summary>
    /// This service manages the operations of URL entity 
    /// </summary>
    public interface IUrlService
    {
        /// <summary>
        /// This method gets a random short url text
        /// </summary>
        /// <param name="length">size of short url text</param>
        /// <returns>returns a random short url text</returns>
        string GetRandomShortUrl(int length);
        /// <summary>
        /// This method gets the URL entity with id
        /// </summary>
        /// <param name="id">id of the URL entity</param>
        /// <returns>returns URL entity with id</returns>
        Task<Url?> GetByIdAsync(Guid? id);
        /// <summary>
        /// This method gets the URL entity with short url text
        /// </summary>
        /// <param name="id">short url text of the URL entity</param>
        /// <returns>returns URL entity with short url text</returns>
        Task<Url?> GetByShortUrlAsync(string? shortUrl);
        /// <summary>
        /// This method adds an URL entity to database
        /// </summary>
        /// <param name="id">URL entity to be added</param>
        /// <returns>returns added URL entity</returns>
        Task AddAsync(Url url);
    }
}
