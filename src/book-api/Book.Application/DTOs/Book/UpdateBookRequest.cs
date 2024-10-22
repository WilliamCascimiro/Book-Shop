
using Book.Application.DTOs.Book;

namespace Book.Application.DTOs.Author
{
    public class UpdateBookRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Value { get; set; }
        public string PurchaseForm { get; set; }

        public List<Guid> AuthorUpdateList { get; set; }
        public List<Guid> SubjectUpdateList { get; set; }
    }
}
