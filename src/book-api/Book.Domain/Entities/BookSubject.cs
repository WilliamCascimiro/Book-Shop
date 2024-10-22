using Book.Domain.Entities.Base;

namespace Book.Domain.Entities
{
    public class BookSubject : BaseDomain
    {
        public Guid BookId { get; set; }
        public Books Book { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
