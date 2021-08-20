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
        List<ProductDTO> AdminGetProduct(Guid? productID =null);
        void AddProduct(ProductEntity product, List<int> categories, List<string> Images);
        bool DeleteProduct(Guid productID);
        List<ProductDTO> RelatedproductsQuery(string categoryName);
        List<UnitDTO> GetUnits();
        List<ProductDTO> GetProduct(int page = 1);
        bool AddToCart(Guid productId);
    }
}
