using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private IProductRepository _ProductRepository;
        private IProductDomainService _ProductDomainService;

        public ProductApplicationService(IProductRepository ProductRepository, IProductDomainService ProductDomainService)
        {
            _ProductRepository = ProductRepository;
            _ProductDomainService = ProductDomainService;
        }

        public List<ProductDTO> GetProduct(Guid? productID)
        {
            return _ProductRepository.GetProduct(productID);
        }

        public ResultDTO AddProduct(ProductDTO product,  List<string> images)
        {
            ProductEntity ProductModel = new ProductEntity();
            ProductModel.Set(AutoMapperExtensions.MapObject<ProductDTO, ProductEntity>(product));
            List<int> categoryID = new List<int>() { 6 }; // ეს სანამ კატეგორიას გადმოვაწვდი product.CategoryIds
            return _ProductDomainService.AddProduct(ProductModel, categoryID, images);
            
        }

        public bool DeleteProduct(Guid ProductID)
        {
            return _ProductDomainService.DeleteProduct(ProductID);

        }
    }
}
