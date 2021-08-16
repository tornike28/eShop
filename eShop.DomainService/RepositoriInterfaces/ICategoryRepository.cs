﻿using eShop.DataTransferObject;
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
        List<CategoryDTO> GetCategories(int categoryID);
        void AddCategory(CategoryEntity category);
        bool CheckCategoryExists(string categoryName);
        bool DeleteCategory(int categoryID);

        

    }
}
