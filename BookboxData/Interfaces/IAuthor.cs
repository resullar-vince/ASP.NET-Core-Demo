using BookboxData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookboxData.Interfaces
{
    public interface IAuthor
    {
        IReadOnlyCollection<Author> GetAuthors();
        Author GetAuthorById(int id);
        IReadOnlyCollection<Book> GetWrittenBooks(int authorId);
        void AddAuthor(Author newAuthor);
        void EditAuthorDetails(Author newAuthorDetails);
        void RemoveAuthor(int id);
    }
}
