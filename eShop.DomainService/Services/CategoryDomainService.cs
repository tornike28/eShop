using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class CategoryDomainService : ICategoryDomainService
    {
        ICategoryRepository _CategoryRepository;
        public CategoryDomainService(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        public ResultDTO AddCategory(CategoryEntity category)
        {
            var validationResponse = new List<string>();
            validationResponse = category.IsValid();

            if (!_CategoryRepository.CheckCategoryExists(category.CategoryName))
            {
                validationResponse.Add("Category already exist");
            }

            if (validationResponse.Count != 0)
            {
                return new ResultDTO()
                {
                    IsError = true,
                    ErrorMessages = validationResponse
                };
            }
            else
            {
                _CategoryRepository.AddCategory(category);
                return new ResultDTO() { IsError = false };
            }
        }

        public bool DeleteCategory(int categoryID)
        {
            return _CategoryRepository.DeleteCategory(categoryID);

        }
    }
}
