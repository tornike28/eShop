﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using eShop.DataBaseRepository.DB.Models;

#nullable disable

namespace eShop.DataBaseRepository.DB
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductsInCategory> ProductsInCategories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<UsersInRole> UsersInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories", "Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "Order");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserAddressId).HasColumnName("UserAddressID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_OrderStatus");

                entity.HasOne(d => d.UserAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_UserAddress");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails", "Order");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus", "Order");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products", "Product");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Units");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImages", "Product");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.IsThumbnail).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImages_Products");
            });

            modelBuilder.Entity<ProductsInCategory>(entity =>
            {
                entity.ToTable("ProductsInCategories", "Product");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsInCategories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductsInCategories_Products");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "User");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Units", "Product");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "User");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.ActivationDate).HasMaxLength(50);

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.SessionId).HasColumnName("SessionID");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("UserAddress", "User");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.FullAddress).HasMaxLength(500);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAddress_Users");
            });

            modelBuilder.Entity<UsersInRole>(entity =>
            {
                entity.ToTable("UsersInRoles", "User");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateChanged).HasColumnType("datetime");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateDeleted).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersInRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInRoles_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}