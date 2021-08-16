using eShop.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.ApplicationService.ServiceInterfaces
{
    public interface ICategoryApplicationService
    {
        List<CategoryDTO> GetCategories(int categoryID);
        ResultDTO AddCategory(CategoryDTO Category);

        bool DeleteCategory(int categoryID);

    }
}
