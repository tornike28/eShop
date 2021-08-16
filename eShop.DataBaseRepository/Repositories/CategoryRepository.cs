using eShop.DataBaseRepository.DB;
using eShop.DataBaseRepository.DB.Models;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataBaseRepository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void AddCategory(CategoryEntity category)
        {

            using (eShopDBContext context = new eShopDBContext())
            {
                Category newCategory = new Category()
                {
                    Name = category.CategoryName,
                    DateCreated = DateTime.Now
                };


                context.Categories.Add(newCategory);

                context.SaveChanges();
            }
        }



        public bool CheckCategoryExists(string categoryName)
        {

            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from c in context.Categories
                             where c.DateDeleted == null && c.Name == categoryName
                             select c).FirstOrDefault();

                return query != null ? false : true;
            }
        }

        public bool DeleteCategory(int categoryID)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var category = (from item in context.Categories
                                where item.Id == categoryID
                                select item).FirstOrDefault();
                if (category == null)
                {
                    return false;
                }
                else
                {
                    category.DateDeleted = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
        }

        public List<CategoryDTO> GetCategories(int categoryID = 0)
        {
            if (categoryID == 0)
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    var query = (from c in context.Categories
                                 select new CategoryDTO
                                 {
                                     Id = c.Id,
                                     CategoryName = c.Name,
                                     DateCreated = c.DateCreated,
                                     Status = c.DateDeleted != null ? Status.Deleted : Status.Active
                                 }).ToList();

                    return query;
                }
            }
            else
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    var query = (from c in context.Categories
                                 where c.Id == categoryID
                                 select new CategoryDTO
                                 {
                                     Id = c.Id,
                                     CategoryName = c.Name,
                                     DateCreated = c.DateCreated,
                                     Status = c.DateDeleted != null ? Status.Deleted : Status.Active
                                 }).ToList();

                    return query;
                }
            }
           
        }
    }
}
