using Book.Domain.Entities.Base;

namespace Book.Domain.Entities
{
    public class Subject : BaseDomain
    {
        public Subject()
        {
        }

        public Subject(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }
        public ICollection<BookSubject> BooksSubject { get; set; }

    }
}
