using System;
using System.Collections.Generic;
using System.Linq;
using BookboxData.DataAcess;
using BookboxData.Interfaces;
using BookboxData.Models;
using Microsoft.EntityFrameworkCore;

namespace BookboxServices.Services
{
    public class BookService : IBook
    {
        private readonly BookContext _context;

        public BookService(BookContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<Book> GetAllBooks()
        {
            return _context.Books
                .Include(book => book.Author)
                .Include(book => book.BookCategories)
                    .ThenInclude(bookCategory => bookCategory.Category).ToList();
        }

        public Book GetBookById(int id)
        {
            return GetAllBooks().SingleOrDefault(book => book.Id == id);
        }

        public IReadOnlyCollection<Category> GetBookCategories(int bookId)
        {
            IReadOnlyCollection<Category> result = new List<Category>();

            if (_context.BookCategories.Any(book => book.BookId == bookId))
            {
                result = (IReadOnlyCollection<Category>)_context
                    .BookCategories
                    .Where(book => book.BookId == bookId)
                    .Include(bookCategory => bookCategory.Category);
            }

            return result;
        }

        public IReadOnlyCollection<Book> GetBooksByCategory(int categoryId)
        {
            IReadOnlyCollection<Book> result = new List<Book>();

            if (_context.BookCategories.AsNoTracking().Any(category => category.CategoryId == categoryId))
            {
                result = (IReadOnlyCollection<Book>)_context
                    .BookCategories
                    .Where(category => category.CategoryId == categoryId)
                    .Include(bookCategory => bookCategory.Book);
            }

            return result;
        }

        public void AddBook(Book newbook)
        {
            _context.Add(newbook);
            _context.SaveChanges();
        }

        public void EditBook(Book newBookDetails)
        {
            try
            {
                Book book = GetBookById(newBookDetails.Id);
                _context.Entry(book).CurrentValues.SetValues(newBookDetails);

                //remove or update child collection items
                var bookCategories = book.BookCategories;

                foreach (var bookCategory in bookCategories)
                {
                    var category = newBookDetails.BookCategories.SingleOrDefault(i => i.CategoryId == bookCategory.CategoryId);
                    if (category != null)
                    {
                        _context.Entry(bookCategory).CurrentValues.SetValues(category);
                    }
                    else
                    {
                        _context.Remove(category);
                    }
                }

                foreach (var category in newBookDetails.BookCategories)
                {
                    if (bookCategories.All(i => i.CategoryId != category.CategoryId))
                    {
                        book.BookCategories.Add(category);
                    }
                }
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public void DeleteBook(int id)
        {
            Book bookToDelete = new Book() { Id = id };
            _context.Entry(bookToDelete).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
