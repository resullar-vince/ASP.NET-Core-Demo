using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bookbox.Models.Authors;
using Bookbox.Models.Utilities;
using BookboxData.Interfaces;
using BookboxData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthor _author;
        public AuthorsController(IAuthor author)
        {
            _author = author;
        }
        public IActionResult Index()
        {
            var authors = _author.GetAuthors().ToList();

            var authorList = authors.Select(author => new AuthorModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                AddedDate = author.AddedDate,
                EmailAddress = author.EmailAddress
            });

            AuthorListModel model = new AuthorListModel()
            {
                AuthorList = authorList
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuthorModel author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Author newAuthor = new Author()
                    {
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        EmailAddress = author.EmailAddress,
                        AddedDate = author.AddedDate
                    };

                    _author.AddAuthor(newAuthor);

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

            return View(author);
        }

        public IActionResult Details(int id)
        {
            Author author = _author.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            AuthorModel model = new AuthorModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                EmailAddress = author.EmailAddress,
                Books = author.Books.ToList()
            };

            return View(model);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Author author = _author.GetAuthorById((int)id);

            if (author == null)
            {
                return NotFound();
            }

            AuthorModel model = new AuthorModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                EmailAddress = author.EmailAddress
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AuthorModel authorToUpdate)
        {
            if (id != authorToUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Author updatedAuthor = new Author()
                {
                    Id = authorToUpdate.Id,
                    FirstName = authorToUpdate.FirstName,
                    LastName = authorToUpdate.LastName,
                    EmailAddress = authorToUpdate.EmailAddress
                };

                _author.EditAuthorDetails(updatedAuthor);

                return RedirectToAction(nameof(Index));
            }

            return View(authorToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAuthor(int? id)
        {
            if (id != null)
            {
                _author.RemoveAuthor((int)id);

                return Ok(new ApiResponse((int)HttpStatusCode.OK, "Record was successfully deleted."));
            }

            return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, "Record is not found. "));
        }
    }
}
