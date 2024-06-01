using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Url : Entity<Guid>
    {
        public string FullUrl { get; set; } = null!;
        public string ShortUrl { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
    }
}
