﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace eShop.DataBaseRepository.DB.Models
{
    public partial class Role
    {
        public Role()
        {
            UsersInRoles = new HashSet<UsersInRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersInRole> UsersInRoles { get; set; }
    }
}