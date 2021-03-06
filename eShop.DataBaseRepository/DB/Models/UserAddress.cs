// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.DB.Models
{
    public partial class UserAddress
    {
        public UserAddress()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FullAddress { get; set; }
        public bool? IsPrimary { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public DateTime? DateDeleted { get; set; }
        public string City { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}