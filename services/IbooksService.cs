using System.Collections.Generic;

namespace LibraryManagement
{
    public interface IBooksService
    {
        ICollection<Book> GetBooks();
        Book GetBookById(int id);
        ICollection<Book> GetBooksByTitle(string title);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}