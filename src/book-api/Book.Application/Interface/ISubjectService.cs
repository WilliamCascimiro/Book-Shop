using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Application.DTOs.Subject;
using Book.Domain.Entities;

namespace Book.Application.Interface
{
    public interface ISubjectService
    {
        Task<bool> CreateAsync(CreateSubjectRequest createSubjectRequest);
        Task<List<Subject>> GetAll();
        Task<Subject> GetById(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Guid id, UpdateSubjectRequest updateSubjectRequest);
    }
}
