using Book.Domain.Entities;
using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repositories.Base;

namespace Book.Infra.Data.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        readonly BookDbContext _context;

        public AuthorRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
