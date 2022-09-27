using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Models
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(string id);
        Category AddCategory(Category category);
        void DeleteCategory(string id);
        void UpdateCategory(Category category);
    }
}
