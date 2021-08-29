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
        List<ProductDTO> AdminGetProduct(Guid? productID = null);
        ResultDTO AddProduct(ProductDTO product, List<string> images);
        bool DeleteProduct(Guid ProductID);
        List<ProductDTO> RelatedProductsQuery(string categoryName);
        List<UnitDTO> GetUnits();
        Task<List<string>> UploadImages(List<IFormFile> imageFiles);
        List<ProductDTO> GetProduct(int page = 1);
        ResultDTO SaveProduct(ProductDTO productDTO, List<string> fileNames);
    }
}
