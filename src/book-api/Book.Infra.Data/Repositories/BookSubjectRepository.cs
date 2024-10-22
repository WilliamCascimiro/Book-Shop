using Book.Domain.Entities;
using Book.Domain.Interfaces;
using Book.Infra.Data.Context;
using Book.Infra.Data.Repositories.Base;

namespace Book.Infra.Data.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        readonly BookDbContext _context;

        public SubjectRepository(BookDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
