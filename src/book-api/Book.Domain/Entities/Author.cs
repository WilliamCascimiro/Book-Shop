using Book.Domain.Entities.Base;

namespace Book.Domain.Entities
{
    public class Author : BaseDomain
    {
        public Author()
        {
        }

        public Author(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public ICollection<BookAuthor> BooksAuthor { get; set; }

    }
}
