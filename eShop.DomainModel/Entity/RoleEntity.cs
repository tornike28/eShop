using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainModel.Entity
{
    public class RoleEntity
    {
        public Guid Id { get; private set; } 
        public string Name { get; private set; }
        public DateTime DateCreated { get;private set; }
        public DateTime? DateChanged { get; private set; }
        public DateTime? DateDeleted { get; private set; }



    }
}
