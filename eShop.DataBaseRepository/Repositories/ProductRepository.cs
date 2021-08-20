using eShop.DataBaseRepository.DB;
using eShop.DataBaseRepository.DB.Models;
using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using eShop.DomainService.RepositoriInterfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace eShop.DataBaseRepository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(ProductEntity product, List<int> categories, List<string> Images)
        {
            List<ProductImage> ProductImages = new List<ProductImage>();
            List<ProductsInCategory> ProductsInCategories = new List<ProductsInCategory>();

            using (var scope = new TransactionScope())
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    try
                    {
                        Product newProduct = new Product()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Quantity = product.Quantity,
                            Description = product.Description,
                            Price = product.Price,
                            UnitId = product.UnitId,
                            DateCreated = DateTime.Now,
                        };
                        foreach (var image in Images)
                        {
                            ProductImage ProductImage = new ProductImage()
                            {
                                ProductId = product.Id,
                                IsThumbnail = true,
                                ImagePath = image
                            };
                            ProductImages.Add(ProductImage);
                        }
                        foreach (var category in categories)
                        {
                            ProductsInCategory ProductInCategory = new ProductsInCategory()
                            {
                                ProductId = product.Id,
                                CategoryId = category
                            };
                            ProductsInCategories.Add(ProductInCategory);
                        }

                        context.Products.Add(newProduct);
                        context.ProductImages.AddRange(ProductImages);
                        context.ProductsInCategories.AddRange(ProductsInCategories);
                        context.SaveChanges();


                    }
                    catch (Exception)
                    {
                        scope.Dispose();
                    }
                    finally
                    {
                        scope.Complete();
                    }
                }
            }

        }
        public bool DeleteProduct(Guid productID)
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var product = (from item in context.Products
                               where item.Id == productID
                               select item).FirstOrDefault();

                if (product == null)
                {
                    return false;
                }
                else
                {
                    product.DateDeleted = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
            }
        }
        public List<ProductDTO> AdminGetProduct(Guid? productID = null)
        {
            if (productID == null)
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    var query = (from pc in context.ProductsInCategories
                                 join p in context.Products on pc.ProductId equals p.Id
                                 join c in context.Categories on pc.CategoryId equals c.Id
                                 join u in context.Units on p.UnitId equals u.Id
                                 join pp in context.ProductImages on p.Id equals pp.ProductId
                                 where pp.IsThumbnail == true && p.DateDeleted == null

                                 select new ProductDTO
                                 {
                                     UniqueID = pc.Id,
                                     ProductId = p.Id,
                                     Name = p.Name,
                                     CategoryName = c.Name,
                                     CreateDate = p.DateCreated,
                                     Description = p.Description,
                                     Price = p.Price,
                                     Quantity = p.Quantity,
                                     UnitName = u.Name,
                                     ThumbnailPhoto = pp.ImagePath
                                 }).ToList();

                    return query;
                }
            }
            else
            {
                using (eShopDBContext context = new eShopDBContext())
                {
                    var query = (from pc in context.ProductsInCategories
                                 join p in context.Products on pc.ProductId equals p.Id
                                 join c in context.Categories on pc.CategoryId equals c.Id
                                 join u in context.Units on p.UnitId equals u.Id
                                 join pp in context.ProductImages on p.Id equals pp.ProductId
                                 where pp.IsThumbnail == true && p.DateDeleted == null && pc.Id == productID

                                 select new ProductDTO
                                 {
                                     UniqueID = pc.Id,
                                     ProductId = p.Id,
                                     Name = p.Name,
                                     CategoryName = c.Name,
                                     CreateDate = p.DateCreated,
                                     Description = p.Description,
                                     Price = p.Price,
                                     Quantity = p.Quantity,
                                     UnitName = u.Name,
                                     ThumbnailPhoto = pp.ImagePath
                                 }).ToList();

                    return query;
                }
            }
        }

        public List<UnitDTO> GetUnits()
        {
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from u in context.Units
                             select new UnitDTO
                             {
                                 UnitID = u.Id,
                                 UnitName = u.Name
                             }).ToList();

                return query;
            }
        }

        public List<ProductDTO> RelatedproductsQuery(string categoryName)
        {

            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from pc in context.ProductsInCategories
                             join p in context.Products on pc.ProductId equals p.Id
                             join c in context.Categories on pc.CategoryId equals c.Id
                             join u in context.Units on p.UnitId equals u.Id
                             join pp in context.ProductImages on p.Id equals pp.ProductId
                             where pp.IsThumbnail == true && p.DateDeleted == null && c.Name == categoryName

                             select new ProductDTO
                             {
                                 UniqueID = pc.Id,
                                 ProductId = p.Id,
                                 Name = p.Name,
                                 CategoryName = c.Name,
                                 CreateDate = p.DateCreated,
                                 Description = p.Description,
                                 Price = p.Price,
                                 Quantity = p.Quantity,
                                 UnitName = u.Name,
                                 ThumbnailPhoto = pp.ImagePath
                             })
                             .OrderBy(x => x.CreateDate)
                             .Take(4)
                             .ToList();

                return query;
            }
        }

        public List<ProductDTO> GetProduct(int page = 1)
        {
            var pageSize = 8;
            using (eShopDBContext context = new eShopDBContext())
            {
                var query = (from pc in context.ProductsInCategories
                             join p in context.Products on pc.ProductId equals p.Id
                             join c in context.Categories on pc.CategoryId equals c.Id
                             join u in context.Units on p.UnitId equals u.Id
                             join pp in context.ProductImages on p.Id equals pp.ProductId
                             where pp.IsThumbnail == true && p.DateDeleted == null

                             select new ProductDTO
                             {
                                 UniqueID = pc.Id,
                                 ProductId = p.Id,
                                 Name = p.Name,
                                 CategoryName = c.Name,
                                 CreateDate = p.DateCreated,
                                 Description = p.Description,
                                 Price = p.Price,
                                 Quantity = p.Quantity,
                                 UnitName = u.Name,
                                 ThumbnailPhoto = pp.ImagePath,
                                 NumberOfPages =  (context.ProductsInCategories.Count()) / pageSize
                             }).Skip((page-1) * pageSize).Take(pageSize).ToList();

                return query;
            }
        }
    }
}
