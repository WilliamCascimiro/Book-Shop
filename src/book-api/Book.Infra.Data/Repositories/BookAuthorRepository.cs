using Book.Domain.Entities;
using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repositories.Base;

namespace Book.Infra.Data.Repositories
{
    public class BookAuthorRepository : BaseRepository<BookAuthor>, IBookAuthorRepository
    {
        readonly BookDbContext _context;

        public BookAuthorRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
