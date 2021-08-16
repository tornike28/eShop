using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class ProductsModel
    {
        public string ProductName { get; set; }
        public Guid ProductID { get; set; }
        public decimal Price { get; set; }
        public string thumbnailPhoto { get; set; }
    }
}
