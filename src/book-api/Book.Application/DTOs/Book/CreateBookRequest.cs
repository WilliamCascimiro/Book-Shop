
namespace Book.Application.DTOs.Book
{
    public class CreateBookRequest
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public decimal Value { get; set; }
        public string PurchaseForm { get; set; }
        
        public List<Guid> AuthorIds { get; set; }        
        public List<Guid> SubjectIds { get; set; }
    }
}
