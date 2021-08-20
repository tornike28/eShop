using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private ICategoryRepository _CategoryRepository;

        private ICategoryDomainService _CategoryDomainService;

        public CategoryApplicationService(ICategoryRepository CategoryRepository, ICategoryDomainService CategoryDomainService)
        {
            _CategoryRepository = CategoryRepository;
            _CategoryDomainService = CategoryDomainService;
        }

        public ResultDTO AddCategory(CategoryDTO Category)
        {
            return _CategoryDomainService.AddCategory(new CategoryEntity(Category.CategoryName));
        }

        public bool DeleteCategory(int categoryID)
        {
            return _CategoryDomainService.DeleteCategory(categoryID);
        }

        public List<CategoryDTO> GetCategories(int? categoryID = null)
        {
            return _CategoryRepository.GetCategories(categoryID);
        }

      
    }
}
