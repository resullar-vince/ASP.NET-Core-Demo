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
    public class CategoryService : ICategory
    {
        private readonly BookContext _context;
        public CategoryService(BookContext context)
        {
            _context = context;
        }
        public IReadOnlyCollection<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        public Category GetCategoryById(int id)
        {
            return GetAllCategories().SingleOrDefault(category => category.Id == id);
        }
        public Category GetCategoryByName(string name)
        {
            return GetAllCategories().SingleOrDefault(category => category.Name == name);
        }
        public void AddCategory(Category newCategory)
        {
            if (GetCategoryByName(newCategory.Name) == null)
            {
                _context.Add(newCategory);
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                Category categoryToDelete = new Category() { Id = id };
                _context.Entry(categoryToDelete).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public void EditCategory(Category newCategoryDetails)
        {
            try
            {
                _context.Categories.Update(newCategoryDetails);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }
    }
}
