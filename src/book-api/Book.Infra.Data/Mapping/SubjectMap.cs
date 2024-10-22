using Book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infra.Data.Mapping
{
    public class SubjectMap : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");
            builder.HasKey(s => s.Id);
            //builder.Property(x => x.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(x => x.Id).HasColumnName("Id").HasDefaultValueSql("NEWID()");
            builder.Property(s => s.Description).HasColumnName("Description").IsRequired().HasMaxLength(100);

            
            builder.HasMany(s => s.BooksSubject)
                   .WithOne(bs => bs.Subject)
                   .HasForeignKey(bs => bs.SubjectId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
