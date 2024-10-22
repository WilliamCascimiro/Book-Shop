using Book.Domain.Entities;
using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Book.Infra.Data.Repositories
{
    public class BookRepository : BaseRepository<Books>, IBookRepository
    {
        readonly BookDbContext _context;

        public BookRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Books> GetById(Guid id)
        {
            var books = await _context.Books
                .Include(x => x.BooksAuthor)
                .ThenInclude(x => x.Author)
                .Include(x => x.BooksSubject)
                .ThenInclude(x => x.Subject)
                .Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return books;
        }
    }
}
