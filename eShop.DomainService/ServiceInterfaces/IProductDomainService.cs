using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface IProductDomainService
    {
        ResultDTO AddProduct(ProductEntity productModel, List<int> categories, List<string> Images);
        bool DeleteProduct(Guid productID);
        ResultDTO SaveProduct(ProductEntity productModel, List<int> categoryIds, List<string> fileNames);
    }
}
