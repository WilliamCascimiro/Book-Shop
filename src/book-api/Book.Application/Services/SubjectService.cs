using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Application.DTOs.Subject;
using Book.Application.Interface;
using Book.Domain.Entities;
using Book.Domain.Interfaces;

namespace Book.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<bool> CreateAsync(CreateSubjectRequest createSubjectRequest)
        {
            try
            {
                if (createSubjectRequest == null)
                    return false;

                Subject subject = new Subject(createSubjectRequest.Description);

                await _subjectRepository.AddAsync(subject);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

        public async Task<List<Subject>> GetAll()
        {
            try
            {
                var authors = await _subjectRepository.GetAll();
                return authors;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return new List<Subject>();
            }
        }

        public async Task<Subject> GetById(Guid id)
        {
            try
            {
                var subject = await _subjectRepository.GetById(id);
                return subject;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return new Subject();
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                await _subjectRepository.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

        public async Task<bool> Update(Guid id, UpdateSubjectRequest updateSubjectRequest)
        {
            try
            {
                var subjectToUpdate = await _subjectRepository.GetById(id);
                if (subjectToUpdate == null)
                {
                    return false;
                }

                subjectToUpdate.Description = updateSubjectRequest.Description;

                await _subjectRepository.Update(subjectToUpdate);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

    }
}
