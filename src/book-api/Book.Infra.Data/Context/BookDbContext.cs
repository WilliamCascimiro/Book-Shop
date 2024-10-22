using Book.Domain.Entities;
using Book.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Book.Infra.Data.Context
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookSubject> BookSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
