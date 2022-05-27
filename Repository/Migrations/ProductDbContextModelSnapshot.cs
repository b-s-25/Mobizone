﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DomainLayer.Address", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("additionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("district")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pincode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("registrationId")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("registrationId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DomainLayer.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DomainLayer.Login", b =>
                {
                    b.Property<int>("loginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("loginId");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("DomainLayer.MasterData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<string>("masterData")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("MasterData");

                    b.Property<int>("parentId")
                        .HasColumnType("int")
                        .HasColumnName("PerentId");

                    b.HasKey("id");

                    b.ToTable("masterDatas");
                });

            modelBuilder.Entity("DomainLayer.ProductBrand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("brandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("DomainLayer.ProductColor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productColor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductColor");
                });

            modelBuilder.Entity("DomainLayer.ProductImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("DomainLayer.ProductModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productModel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductModel");
                });

            modelBuilder.Entity("DomainLayer.ProductRam", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productRam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductRam");
                });

            modelBuilder.Entity("DomainLayer.ProductSim", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productSim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductSim");
                });

            modelBuilder.Entity("DomainLayer.ProductStorage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Specificationid")
                        .HasColumnType("int");

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("storageCapacity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Specificationid");

                    b.ToTable("ProductStorage");
                });

            modelBuilder.Entity("DomainLayer.Products", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("createdBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("deletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("productModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productPrice")
                        .HasColumnType("int");

                    b.Property<int>("productStatus")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("specificationId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DomainLayer.Registration", b =>
                {
                    b.Property<int>("registrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("createdBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("createdOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modifiedBy")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime>("modifiedOn")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedOn");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("registrationId");

                    b.ToTable("Register");
                });

            modelBuilder.Entity("DomainLayer.Specification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Productsid")
                        .HasColumnType("int");

                    b.Property<string>("created_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("modified_by")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modified_on")
                        .HasColumnType("datetime2");

                    b.Property<int>("productBrandId")
                        .HasColumnType("int");

                    b.Property<int>("productColorId")
                        .HasColumnType("int");

                    b.Property<int>("productImageId")
                        .HasColumnType("int");

                    b.Property<int>("productModelId")
                        .HasColumnType("int");

                    b.Property<int>("productRamId")
                        .HasColumnType("int");

                    b.Property<int>("productSimId")
                        .HasColumnType("int");

                    b.Property<int>("productStorageId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productsid");

                    b.HasIndex("productBrandId");

                    b.HasIndex("productColorId");

                    b.HasIndex("productImageId");

                    b.HasIndex("productModelId");

                    b.HasIndex("productRamId");

                    b.HasIndex("productSimId");

                    b.HasIndex("productStorageId");

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("DomainLayer.UserCheckOut", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("addressId")
                        .HasColumnType("int");

                    b.Property<int?>("cancelRequested")
                        .HasColumnType("int");

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("paymentModeId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("addressId");

                    b.HasIndex("userId");

                    b.ToTable("userCheckOut");
                });

            modelBuilder.Entity("DomainLayer.UserOrders", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("paymentId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("registrationId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.HasIndex("registrationId");

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("DomainLayer.Address", b =>
                {
                    b.HasOne("DomainLayer.Registration", null)
                        .WithMany("address")
                        .HasForeignKey("registrationId");
                });

            modelBuilder.Entity("DomainLayer.ProductBrand", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productBrands")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.ProductColor", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productColors")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.ProductImage", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productImages")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.ProductModel", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productModels")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.ProductRam", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productRams")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.ProductSim", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productSims")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.ProductStorage", b =>
                {
                    b.HasOne("DomainLayer.Specification", null)
                        .WithMany("productStorages")
                        .HasForeignKey("Specificationid");
                });

            modelBuilder.Entity("DomainLayer.Specification", b =>
                {
                    b.HasOne("DomainLayer.Products", null)
                        .WithMany("Specifications")
                        .HasForeignKey("Productsid");

                    b.HasOne("DomainLayer.ProductBrand", "productBrand")
                        .WithMany()
                        .HasForeignKey("productBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ProductColor", "productColor")
                        .WithMany()
                        .HasForeignKey("productColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ProductImage", "productImage")
                        .WithMany()
                        .HasForeignKey("productImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ProductModel", "productModel")
                        .WithMany()
                        .HasForeignKey("productModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ProductRam", "productRam")
                        .WithMany()
                        .HasForeignKey("productRamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ProductSim", "productSim")
                        .WithMany()
                        .HasForeignKey("productSimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ProductStorage", "productStorage")
                        .WithMany()
                        .HasForeignKey("productStorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("productBrand");

                    b.Navigation("productColor");

                    b.Navigation("productImage");

                    b.Navigation("productModel");

                    b.Navigation("productRam");

                    b.Navigation("productSim");

                    b.Navigation("productStorage");
                });

            modelBuilder.Entity("DomainLayer.UserCheckOut", b =>
                {
                    b.HasOne("DomainLayer.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Registration", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");

                    b.Navigation("user");
                });

            modelBuilder.Entity("DomainLayer.UserOrders", b =>
                {
                    b.HasOne("DomainLayer.Products", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.Registration", "users")
                        .WithMany()
                        .HasForeignKey("registrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DomainLayer.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DomainLayer.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DomainLayer.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Products", b =>
                {
                    b.Navigation("Specifications");
                });

            modelBuilder.Entity("DomainLayer.Registration", b =>
                {
                    b.Navigation("address");
                });

            modelBuilder.Entity("DomainLayer.Specification", b =>
                {
                    b.Navigation("productBrands");

                    b.Navigation("productColors");

                    b.Navigation("productImages");

                    b.Navigation("productModels");

                    b.Navigation("productRams");

                    b.Navigation("productSims");

                    b.Navigation("productStorages");
                });
#pragma warning restore 612, 618
        }
    }
}
