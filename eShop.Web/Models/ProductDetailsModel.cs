using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Web.Models
{
    public class ProductDetailsModel
    {
        public List<ProductDTO> RelatedProductsInfo { get; set; }
        public ProductDTO ProductDetailInfo { get;  set; }
    }
}
