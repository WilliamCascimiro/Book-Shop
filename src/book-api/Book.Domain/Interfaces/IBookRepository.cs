using Book.Domain.Entities;
using Book.Domain.Interfaces.Base;

namespace Book.Domain.Interfaces
{
    public interface IBookRepository : IBaseRepository<Books>
    {
    }
}
