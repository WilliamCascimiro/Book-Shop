using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.Data.Mapping
{
    internal class BookAuthorMap : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthor");
            builder.HasKey(ba => new { ba.BookId, ba.AuthorId });

            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");

            builder.HasOne(ba => ba.Book)
                   .WithMany(b => b.BooksAuthor)
                   .HasForeignKey(ba => ba.BookId);

            builder.HasOne(ba => ba.Author)
                   .WithMany(a => a.BooksAuthor)
                   .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
