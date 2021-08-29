using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetCategories(int? categoryID = null);
        void AddCategory(CategoryEntity category);
        bool CheckCategoryExists(string categoryName);
        bool DeleteCategory(int categoryID);
        void SaveCategory(CategoryDTO categoryDTO);
    }
}
