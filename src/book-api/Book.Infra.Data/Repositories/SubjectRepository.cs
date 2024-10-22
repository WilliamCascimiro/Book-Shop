using Book.Domain.Entities;
using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repositories.Base;

namespace Book.Infra.Data.Repositories
{
    public class BookSubjectRepository : BaseRepository<BookSubject>, IBookSubjectRepository
    {
        readonly BookDbContext _context;

        public BookSubjectRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
