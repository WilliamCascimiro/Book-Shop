using Book.Domain.Entities.Base;

namespace Book.Domain.Entities
{
    public class BookAuthor : BaseDomain
    {
        public Guid BookId { get; set; }
        public Books Book { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
