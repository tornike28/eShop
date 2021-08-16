using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }

        public List<int> CategoryIds { get; set; }

        public int CategoryId { get; set; }

        public string ThumbnailPhoto { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public string UnitName { get; set; }
        public int UnitID { get; set; }

        public DateTime CreateDate { get; set; }

        public List<string> ImageFiles { get; set; }
        public Guid UniqueID { get; set; }
    }
}
