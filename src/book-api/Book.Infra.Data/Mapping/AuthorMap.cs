using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.Data.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);

            builder.HasMany(a => a.BooksAuthor)
                   .WithOne(ba => ba.Author)
                   .HasForeignKey(ba => ba.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
