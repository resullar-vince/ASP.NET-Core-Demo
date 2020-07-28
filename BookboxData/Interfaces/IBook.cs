using BookboxData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookboxData.Interfaces
{
    public interface IBook
    {
        IReadOnlyCollection<Book> GetAllBooks();
        IReadOnlyCollection<Book> GetBooksByCategory(int categoryId);
        IReadOnlyCollection<Category> GetBookCategories(int bookId);
        Book GetBookById(int id);
        void AddBook(Book newbook);
        void EditBook(Book newBookDetails);
        void DeleteBook(int id);
    }
}
