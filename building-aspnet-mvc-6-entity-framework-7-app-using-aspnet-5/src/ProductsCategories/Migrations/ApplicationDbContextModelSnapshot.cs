using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProductsCategories.Models;

namespace ProductsCategories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16341");

            modelBuilder.Entity("ProductsCategories.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");
                });

            modelBuilder.Entity("ProductsCategories.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("Price");

                    b.Property<string>("ProductName");

                    b.HasKey("ProductId");
                });

            modelBuilder.Entity("ProductsCategories.Models.Product", b =>
                {
                    b.HasOne("ProductsCategories.Models.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
