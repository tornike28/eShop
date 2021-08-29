using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entity
{
    public class ProductEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Quantity { get; private set; }
        public byte UnitId { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateChanged { get; private set; }
        public DateTime? DateDeleted { get; private set; }

        public void Set(ProductEntity product)
        {

            Id = product.Id != Guid.Empty ? product.Id : Guid.NewGuid();
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;
            UnitId = product.UnitId;
            DateCreated = product.DateCreated;
            DateChanged = product.DateChanged;
            DateDeleted = product.DateDeleted;
        }

        public List<string> IsValid()
        {
            List<string> Errorresult = new List<string>();
            if (string.IsNullOrEmpty(this.Name))
            {
                Errorresult.Add(ProductErrors.Name_Is_Empty.ToString());
            }
            if (string.IsNullOrEmpty(this.Description))
            {
                Errorresult.Add(ProductErrors.Description_Is_Not_Valid.ToString());
            }
            if (this.Price == 0)
            {
                Errorresult.Add(ProductErrors.Price_Is_Empty.ToString());
            }
            if (this.Quantity == 0)
            {
                Errorresult.Add(ProductErrors.Quantity_Is_Empty.ToString());
            }
            //if (this.UnitId )
            //{
            //    Errorresult.Add(ProductErrors.UnitId_Is_Empty.ToString());
            //}
            return Errorresult;
        }
    }
    public enum ProductErrors
    {
        Name_Is_Empty = 0,
        Description_Is_Not_Valid = 1,
        Price_Is_Empty = 2,
        Quantity_Is_Empty = 3,
        UnitId_Is_Empty = 4,
    }
}