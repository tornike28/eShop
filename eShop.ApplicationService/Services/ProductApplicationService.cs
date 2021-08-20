using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using eShop.Utility;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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

        public List<ProductDTO> AdminGetProduct(Guid? productID = null)
        {
            return _ProductRepository.AdminGetProduct(productID);
        }

        public ResultDTO AddProduct(ProductDTO product, List<string> images)
        {
            ProductEntity ProductModel = new ProductEntity();
            ProductModel.Set(AutoMapperExtensions.MapObject<ProductDTO, ProductEntity>(product));

            return _ProductDomainService.AddProduct(ProductModel, product.CategoryIds, images);

        }

        public bool DeleteProduct(Guid ProductID)
        {
            return _ProductDomainService.DeleteProduct(ProductID);

        }

        public List<ProductDTO> RelatedProductsQuery(string categoryName)
        {
            return _ProductRepository.RelatedproductsQuery(categoryName);
        }

        public List<UnitDTO> GetUnits()
        {
            return _ProductRepository.GetUnits();
        }

        public async Task<List<string>> UploadImages(List<IFormFile> imageFiles)
        {
            List<string> fileNames = new List<string>();

            foreach (var file in imageFiles)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\Upload\\");
                bool basePathExists = Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                fileName = $"{ Guid.NewGuid()}{ extension}";
                var filePath = Path.Combine(basePath, fileName);
                var potoPath = Path.Combine(@"\Upload", fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    fileNames.Add(potoPath);
                }
            }
            return fileNames;
        }

        public List<ProductDTO> GetProduct(int page = 1)
        {
            return _ProductRepository.GetProduct(page);
        }
    }
}
