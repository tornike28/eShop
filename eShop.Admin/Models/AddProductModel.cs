using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Models
{
    public class AddProductModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public int UnitID { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public List<int> CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string UnitName { get; set; }

    }
}
