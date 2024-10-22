using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Application.Interface;
using Book.Domain.Entities;
using Book.Domain.Interfaces;

namespace Book.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<bool> CreateAsync(CreateAuthorRequest createAuthorRequest)
        {
            try
            {
                if (createAuthorRequest == null)
                    return false;

                Author author = new Author(createAuthorRequest.Name);

                await _authorRepository.AddAsync(author);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

        public async Task<List<Author>> GetAll()
        {
            try
            {
                var authors = await _authorRepository.GetAll();
                return authors;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return new List<Author>();
            }
        }

        public async Task<Author> GetById(Guid id)
        {
            try
            {
                var author = await _authorRepository.GetById(id);
                return author;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return new Author();
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                await _authorRepository.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

        public async Task<bool> Update(Guid id, UpdateAuthorRequest updateAuthorRequest)
        {
            try
            {
                var authorToUpdate = await _authorRepository.GetById(id);
                if (authorToUpdate == null)
                {
                    return false;
                }

                authorToUpdate.Name = updateAuthorRequest.Name;

                await _authorRepository.Update(authorToUpdate);
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
