using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using Bookbox.Models.Books;
using Bookbox.Models.Categories;
using Bookbox.Models.Utilities;
using BookboxData.Interfaces;
using BookboxData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBook _book;
        private readonly IAuthor _author;
        private readonly ICategory _category;
        public BooksController(IBook book, IAuthor author, ICategory category)
        {
            _book = book;
            _author = author;
            _category = category;
        }
        public IActionResult Index()
        {
            var bookModel = _book.GetAllBooks();
            var listingResult = bookModel.Select(result => new BookListingDetailsModel
            {
                Id = result.Id,
                ImageUrl = result.ImageUrl,
                Title = result.Title,
                Author = result.Author.FirstName + " " + result.Author.LastName,
                Synopsis = result.Synopsis,
                PublishedDate = result.PublishedDate.ToString("MM/dd/yyyy"),
                Price = result.Price,
                Categories = result.BookCategories.Select(s => s.Category).ToList()
            });

            BookListModel model = new BookListModel()
            {
                BookList = listingResult
            };

            return View(model);
        }

        //GET
        public IActionResult Create()
        {
            PopulateCodes();

            return View();
        }

        public IActionResult Details(int id)
        {
            Book bookDetails = _book.GetBookById(id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            BookModel book = new BookModel
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                Price = bookDetails.Price,
                AuthorName = bookDetails.Author.FirstName + " " + bookDetails.Author.LastName,
                Synopsis = bookDetails.Synopsis,
                PublishedDate = bookDetails.PublishedDate,
                ImageUrl = bookDetails.ImageUrl,
                BookCategories = bookDetails.BookCategories
            };

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel newBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Book newBookEntry = new Book()
                    {
                        Title = newBook.Title,
                        Synopsis = newBook.Synopsis,
                        ImageUrl = newBook.ImageUrl,
                        AddedDate = newBook.AddedDate,
                        Price = newBook.Price,
                        PublishedDate = newBook.PublishedDate,
                        BookCategories = new List<BookCategory>(),
                        Author = _author.GetAuthorById(newBook.AuthorId)
                    };

                    foreach (var category in newBook.CategoryIds)
                    {
                        var categoryToAdd = new BookCategory { BookId = newBookEntry.Id, CategoryId = category };
                        newBookEntry.BookCategories.Add(categoryToAdd);
                    }

                    _book.AddBook(newBookEntry);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            PopulateCodes();
            return View(newBook);
        }

        public IActionResult Edit(int? id)
        {
            Book bookDetails = _book.GetBookById((int)id);

            if (id == null || bookDetails == null)
            {
                return NotFound();
            }

            BookModel bookToEdit = new BookModel()
            {
                Id = bookDetails.Id,
                Title = bookDetails.Title,
                AuthorId = bookDetails.Author.Id,
                Synopsis = bookDetails.Synopsis,
                Price = bookDetails.Price,
                PublishedDate = bookDetails.PublishedDate,
                ImageUrl = bookDetails.ImageUrl,
                CategoryIds = bookDetails.BookCategories.Select(s => s.CategoryId).ToList()
            };

            PopulateCodes(bookToEdit.CategoryIds);

            return View(bookToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BookModel bookToUpdate)
        {
            try
            {
                if (id != bookToUpdate.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    Book editedBook = new Book()
                    {
                        Id = bookToUpdate.Id,
                        Title = bookToUpdate.Title,
                        Synopsis = bookToUpdate.Synopsis,
                        ImageUrl = bookToUpdate.ImageUrl,
                        AddedDate = bookToUpdate.AddedDate,
                        Price = bookToUpdate.Price,
                        PublishedDate = bookToUpdate.PublishedDate,
                        BookCategories = new Collection<BookCategory>(),
                        Author = _author.GetAuthorById(bookToUpdate.AuthorId)
                    };

                    foreach (var category in bookToUpdate.CategoryIds)
                    {
                        var categoryToAdd = new BookCategory { BookId = editedBook.Id, CategoryId = category };
                        editedBook.BookCategories.Add(categoryToAdd);
                    }
                    
                    _book.EditBook(editedBook);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            PopulateCodes();
            return View(bookToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            if (id != null)
            {
               _book.DeleteBook((int)id);

                return Ok(new ApiResponse((int)HttpStatusCode.OK, "Record was successfully deleted."));
            }

            return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, "Record is not found. "));
        }

        private void PopulateCodes(IList<int> categories = null)
        {
            var authors = _author.GetAuthors().ToList();

            ViewData["AllAuthors"] = authors.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName
            }).ToList();

            var allCategories = _category.GetAllCategories();

            var categoryList = new List<CategoryAssignedModel>();

            categoryList = allCategories.Select(s => new CategoryAssignedModel
            {
                Id = s.Id,
                Name = s.Name,
                IsAssigned = categories != null && categories.Contains(s.Id)
            }).ToList();

            ViewData["CategoryList"] = categoryList;
        }
    }
}

