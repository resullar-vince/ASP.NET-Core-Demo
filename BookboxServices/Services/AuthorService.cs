using BookboxData.DataAcess;
using BookboxData.Interfaces;
using BookboxData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookboxServices.Services
{
    public class AuthorService : IAuthor
    {
        private readonly BookContext _context;

        public AuthorService(BookContext context)
        {
            _context = context;
        }
        
        public IReadOnlyCollection<Author> GetAuthors()
        {
            return _context.Authors
                .Include(author => author.Books)
                .ThenInclude(book => book.BookCategories)
                    .ThenInclude(category => category.Category).ToList();
        }

        public Author GetAuthorById(int id)
        {
            return GetAuthors().SingleOrDefault(author => author.Id == id);
        }

        public IReadOnlyCollection<Book> GetWrittenBooks(int authorId)
        {
            return _context.Authors.SingleOrDefault(author => author.Id == authorId).Books.ToList();
        }

        public void AddAuthor(Author newAuthor)
        {
            _context.Add(newAuthor);
            _context.SaveChanges();
        }

        public void EditAuthorDetails(Author newAuthorDetails)
        {
            Author authorToUpdate = GetAuthorById(newAuthorDetails.Id);

            if (authorToUpdate != null)
            {
                try
                {
                    _context.Entry(authorToUpdate).CurrentValues.SetValues(newAuthorDetails);
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw new DbUpdateException(ex.Message);
                }
            }
        }

        public void RemoveAuthor(int id)
        {
            Author authorToDelete = new Author() { Id = id };
            _context.Entry(authorToDelete).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
