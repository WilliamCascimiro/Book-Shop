using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Domain.Entities;

namespace Book.Application.Interface
{
    public interface IAuthorService
    {
        Task<bool> CreateAsync(CreateAuthorRequest createAuthorRequest);
        Task<List<Author>> GetAll();
        Task<Author> GetById(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, UpdateAuthorRequest updateAuthorRequest);
    }
}
