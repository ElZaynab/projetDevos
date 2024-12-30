using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public class BooksService : IBooksService
    {
        private readonly List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "9780743273565", Price = 25.99M, Year = 1925, Quantity = 10 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "0061120081", Price = 19.99M, Year = 1960, Quantity = 7 },
            new Book { Id = 3, Title = "1984", Author = "George Orwell", ISBN = "9780451524935", Price = 12.50M, Year = 1949, Quantity = 12 },
            new Book { Id = 4, Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "9780241950425", Price = 15.75M, Year = 1951, Quantity = 5 },
            new Book { Id = 5, Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780547928227", Price = 22.95M, Year = 1937, Quantity = 8 }
        };

        public ICollection<Book> GetBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public ICollection<Book> GetBooksByTitle(string title) => _books.Where(b => b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase)).ToList();

        public void AddBook(Book book)
        {
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Price = book.Price;
                existingBook.Year = book.Year;
                existingBook.Quantity = book.Quantity;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
