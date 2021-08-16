using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entity
{
    public class CategoryEntity
    {
        public int? Id { get; private set; }
        public string CategoryName { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateChanged { get; private set; }
        public DateTime? DateDeleted { get; private set; }

        //public void Set(CategoryEntity categoryEntity)
        //{
        //    Id = categoryEntity.Id;
        //    CategoryName = categoryEntity.CategoryName;
        //    DateCreated = DateTime.Now;
        //    DateChanged = categoryEntity.DateChanged;
        //    DateDeleted = categoryEntity.DateDeleted;
        //}
        public CategoryEntity(string categoryName)
        {
            CategoryName = categoryName;
            DateCreated = DateTime.Now;
        }


        public List<string> IsValid()
        {
            if (string.IsNullOrEmpty(this.CategoryName))
            {
                return new List<string>() { "Category_Name_Is_Empty" };
            }
            return new List<string>();
        }
    }
}
