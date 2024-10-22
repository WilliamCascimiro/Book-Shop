using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Book.Domain.Entities;

namespace Book.Infra.Data.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(b => b.Id);
            //builder.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired().HasMaxLength(200);
            builder.Property(b => b.Value).HasColumnName("Value").IsRequired();
            builder.Property(b => b.PurchaseForm).HasColumnName("PurchaseForm").IsRequired().HasMaxLength(50);
            
            builder.HasMany(b => b.BooksAuthor)
                   .WithOne(ba => ba.Book)
                   .HasForeignKey(ba => ba.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BooksSubject)
                   .WithOne(bs => bs.Book)
                   .HasForeignKey(bs => bs.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
