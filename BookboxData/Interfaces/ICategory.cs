using BookboxData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookboxData.Interfaces
{
    public interface ICategory
    {
        IReadOnlyCollection<Category> GetAllCategories();
        Category GetCategoryById(int id);
        Category GetCategoryByName(string name);
        void AddCategory(Category newCategory);
        void EditCategory(Category newCategoryDetails);
        void DeleteCategory(int id);
    }
}
