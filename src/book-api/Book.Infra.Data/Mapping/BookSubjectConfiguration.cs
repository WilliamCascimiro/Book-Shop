using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infra.Data.Mapping
{
    public class BookSubjectMap : IEntityTypeConfiguration<BookSubject>
    {
        public void Configure(EntityTypeBuilder<BookSubject> builder)
        {
            builder.ToTable("BookSubject");
            builder.HasKey(bs => new { bs.BookId, bs.SubjectId });

            builder.HasKey(a => a.Id);
            builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");

            builder.HasOne(bs => bs.Book)
                   .WithMany(b => b.BooksSubject)
                   .HasForeignKey(bs => bs.BookId);

            builder.HasOne(bs => bs.Subject)
                   .WithMany(s => s.BooksSubject)
                   .HasForeignKey(bs => bs.SubjectId);
        }
    }
}
