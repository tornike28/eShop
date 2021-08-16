using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.RepositoriInterfaces
{
    public interface IProductRepository
    {
        List<ProductDTO> GetProduct(Guid? productID);

        void AddProduct(ProductEntity product, List<int> categories, List<string> Images);
        bool DeleteProduct(Guid productID);

    }
}
