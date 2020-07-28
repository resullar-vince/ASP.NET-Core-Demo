using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Bookbox.Models.Categories;
using Bookbox.Models.Utilities;
using BookboxData.Interfaces;
using BookboxData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }
        public IActionResult Index()
        {
            var categories = _category.GetAllCategories();

            var categoryList = categories.Select(result => new CategoryListingDetailsModel
            {
                Id = result.Id,
                Name = result.Name,
                AddedDate =result.AddedDate.ToString("MM/dd/yyyy")
            });

            CategoryListModel model = new CategoryListModel()
            {
                CategoryList = categoryList
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category newCategory = new Category()
                    {
                        Name = category.Name,
                        AddedDate = category.AddedDate
                    };

                    _category.AddCategory(newCategory);

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

            return View(category);
        }
        public IActionResult Edit(int? id)
        {
            Category categoryDetails = _category.GetCategoryById((int)id);

            if (id == null || categoryDetails == null)
            {
                return NotFound();
            }

            CategoryModel categoryToUpdate = new CategoryModel()
            {
                Id = categoryDetails.Id,
                Name = categoryDetails.Name,
                AddedDate = categoryDetails.AddedDate
            };

            return View(categoryToUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, CategoryModel catogoryToUpdate)
        {
            try
            {
                if (id != catogoryToUpdate.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    Category editedCategory = new Category()
                    {
                        Id = catogoryToUpdate.Id,
                        Name = catogoryToUpdate.Name,
                    };

                    _category.EditCategory(editedCategory);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            

            return View(catogoryToUpdate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            if (id != null)
            {
                _category.DeleteCategory((int)id);

                return Ok(new ApiResponse((int)HttpStatusCode.OK, "Record was successfully deleted."));
            }

            return NotFound(new ApiResponse((int)HttpStatusCode.NotFound, "Record is not found. "));
        }
    }
}
