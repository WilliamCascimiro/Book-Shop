using Book.Domain.Entities.Base;

namespace Book.Domain.Entities
{
    public class Books : BaseDomain
    {
        public Books()
        {
        }

        public Books(string title, decimal value, string purchaseForm)
        {
            this.Title = title;
            this.Value = value;
            this.PurchaseForm = purchaseForm;
        }

        public string Title { get; set; }
        public decimal Value { get; set; }
        public string PurchaseForm { get; set; } // Ex: Balcão, Internet, etc.
        public ICollection<BookAuthor> BooksAuthor { get; set; }
        public ICollection<BookSubject> BooksSubject { get; set; }
    }
}
