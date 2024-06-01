using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class UrlConfiguration : IEntityTypeConfiguration<Url>
    {
        public void Configure(EntityTypeBuilder<Url> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullUrl).IsRequired().HasMaxLength(450); //the max size for an index entry is 900 bytes, 450 chars for nvarchar
            builder.Property(x => x.ShortUrl).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.FullUrl);
            builder.HasIndex(x => x.ShortUrl).IsUnique();
        }
    }
}
