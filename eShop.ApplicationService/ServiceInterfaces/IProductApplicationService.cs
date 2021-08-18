using eShop.DataTransferObject;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface IProductApplicationService
    {
        List<ProductDTO> GetProduct(int? page ,Guid? productID);
        ResultDTO AddProduct(ProductDTO product, List<string> images);
        bool DeleteProduct(Guid ProductID);
        List<ProductDTO> RelatedProductsQuery(string categoryName);
    }
}
