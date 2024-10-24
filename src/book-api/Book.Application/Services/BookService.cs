﻿using Book.Application.DTOs.Author;
using Book.Application.DTOs.Book;
using Book.Application.Interface;
using Book.Domain.Entities;
using Book.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Book.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookSubjectRepository _bookSubjectRepository;
        private readonly IBookAuthorRepository _bookAuthorRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public BookService(IBookRepository bookRepository, IBookSubjectRepository bookSubjectRepository, IBookAuthorRepository bookAuthorRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _bookSubjectRepository = bookSubjectRepository;
            _bookAuthorRepository = bookAuthorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(CreateBookRequest createBookRequest)
        {
            try
            {
                if (createBookRequest == null)
                    return false;

                createBookRequest.Id = Guid.NewGuid();

                var book = new Books
                {
                    Title = createBookRequest.Title,
                    Value = createBookRequest.Value,
                    PurchaseForm = createBookRequest.PurchaseForm,
                    BooksAuthor = createBookRequest.AuthorIds.Select(authorId => new BookAuthor
                    {
                        Id = Guid.NewGuid(),
                        AuthorId = authorId,
                        BookId = createBookRequest.Id
                    }).ToList(),
                    BooksSubject = createBookRequest.SubjectIds.Select(subjectId => new BookSubject
                    {
                        Id = Guid.NewGuid(),
                        SubjectId = subjectId,
                        BookId = createBookRequest.Id
                    }).ToList()
                };


                await _bookRepository.AddAsync(book);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

        public async Task<List<Books>> GetAll()
        {
            try
            {
                var bookList = await _bookRepository.GetAll();
                return bookList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return new List<Books>();
            }
        }

        public async Task<BookDetail> GetById(Guid id)
        {
            try
            {
                var book = await _bookRepository.GetById(id);

                BookDetail newBook = new BookDetail();

                newBook.Id = book.Id;
                newBook.Title = book.Title;
                newBook.Value = book.Value;
                newBook.PurchaseForm = book.PurchaseForm;
                newBook.AuthorDetails = new List<BookAuthorDetail>();
                newBook.SubjectDetails = new List<BookSubjectDetail>();

                foreach (var authorDetails in book.BooksAuthor)
                {
                    var bookAuthorDetail = new BookAuthorDetail();
                    bookAuthorDetail.Id = authorDetails.Author.Id;
                    bookAuthorDetail.Name = authorDetails.Author.Name;

                    newBook.AuthorDetails.Add(bookAuthorDetail);
                }

                foreach (var subjectDetails in book.BooksSubject)
                {
                    var bookAuthorDetail = new BookSubjectDetail();
                    bookAuthorDetail.Id = subjectDetails.Subject.Id;
                    bookAuthorDetail.Description = subjectDetails.Subject.Description;

                    newBook.SubjectDetails.Add(bookAuthorDetail);
                }


                return newBook;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return new BookDetail();
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                await _bookRepository.Remove(id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR BBB");
                return false;
            }
        }

        public async Task<bool> Update(Guid id, UpdateBookRequest updateBookRequest)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var bookAuthorList = await _bookAuthorRepository.Find(x => x.BookId == id);
                var bookSubjectList = await _bookSubjectRepository.Find(x => x.BookId == id);

                await _bookAuthorRepository.RemoveRange(bookAuthorList);
                await _bookSubjectRepository.RemoveRange(bookSubjectList);

                var bookToUpdate = await _bookRepository.GetById(id);
                if (bookToUpdate == null)
                    return false;

                bookToUpdate.Title = updateBookRequest.Title;
                bookToUpdate.Value = updateBookRequest.Value;
                bookToUpdate.PurchaseForm = updateBookRequest.PurchaseForm;

                foreach (var authorDetails in updateBookRequest.AuthorUpdateList)
                {
                    var bookAuthor = new BookAuthor();
                    bookAuthor.BookId = updateBookRequest.Id;
                    bookAuthor.AuthorId = authorDetails;

                    bookToUpdate.BooksAuthor.Add(bookAuthor);
                }

                foreach (var subjectId in updateBookRequest.SubjectUpdateList)
                {
                    var bookSubject = new BookSubject();
                    bookSubject.BookId = updateBookRequest.Id;
                    bookSubject.SubjectId = subjectId;

                    bookToUpdate.BooksSubject.Add(bookSubject);
                }

                await _bookRepository.Update(bookToUpdate);

                await _unitOfWork.SaveChangesAndCommitAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                return false;
            }
        }



    }
}
