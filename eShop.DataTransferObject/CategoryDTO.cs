using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DataTransferObject
{
    public class CategoryDTO
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime DateCreated { get; set; }
        public Status? Status { get; set; }
    }
    public enum Status
    {
        Active = 1,
        Deleted = 2,
        Blocked = 3
    }
}
