using eShop.DataTransferObject;
using eShop.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainService.ServiceInterfaces
{
    public interface ICategoryDomainService
    {
        ResultDTO AddCategory(CategoryEntity category);
        bool DeleteCategory(int categoryID);

    }
}
