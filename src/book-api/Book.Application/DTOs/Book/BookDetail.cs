using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.DTOs.Book
{
    public class BookDetail
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public decimal Value { get; set; }
        public string PurchaseForm { get; set; }

        public List<BookAuthorDetail> AuthorDetails { get; set; }
        public List<BookSubjectDetail> SubjectDetails { get; set; }
    }

    public class BookAuthorDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class BookSubjectDetail
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
