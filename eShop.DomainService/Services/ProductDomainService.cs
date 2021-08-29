using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using eShop.DomainService.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private IProductRepository _ProductRepository;
        public ProductDomainService(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        public ResultDTO AddProduct(ProductEntity productModel, List<int> categories, List<string> images)
        {
            var validationResponse = new List<string>();
            validationResponse = productModel.IsValid();


            if (validationResponse.Count != 0)
            {
                return new ResultDTO()
                {
                    IsError = true,
                    ErrorMessages = validationResponse
                };
            }
            else
            {
                _ProductRepository.AddProduct(productModel, categories, images);
                return new ResultDTO() { IsError = false };
            }
        }


        public bool DeleteProduct(Guid productID)
        {
            return _ProductRepository.DeleteProduct(productID);

        }

        public ResultDTO SaveProduct(ProductEntity productModel, List<int> categoryIds, List<string> fileNames)
        {
            var validationResponse = new List<string>();
            validationResponse = productModel.IsValid();


            if (validationResponse.Count != 0)
            {
                return new ResultDTO()
                {
                    IsError = true,
                    ErrorMessages = validationResponse
                };
            }
            else
            {
                _ProductRepository.SaveProduct(productModel, categoryIds, fileNames);
                return new ResultDTO() { IsError = false };
            }
        }
    }
}
