using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Domain.Entities;

namespace Book.Application.Interface
{
    public interface IBookService
    {
        Task<bool> CreateAsync(CreateBookRequest reserva);
        Task<List<Books>> GetAll();
        Task<BookDetail> GetById(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, UpdateBookRequest updateBookRequest);
    }
}
