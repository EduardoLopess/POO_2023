﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiAS.Data;

#nullable disable

namespace apiAS.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("apiAS.Domain.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("IdClient");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("apiAS.Domain.Entities.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<int?>("SaleIdSale")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdProduct");

                    b.HasIndex("SaleIdSale");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("apiAS.Domain.Entities.Sale", b =>
                {
                    b.Property<int>("IdSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal")
                        .HasColumnName("ValorTotal");

                    b.HasKey("IdSale");

                    b.HasIndex("ClientId");

                    b.ToTable("Venda", (string)null);
                });

            modelBuilder.Entity("apiAS.Domain.Entities.Product", b =>
                {
                    b.HasOne("apiAS.Domain.Entities.Sale", null)
                        .WithMany("Products")
                        .HasForeignKey("SaleIdSale");
                });

            modelBuilder.Entity("apiAS.Domain.Entities.Sale", b =>
                {
                    b.HasOne("apiAS.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("apiAS.Domain.Entities.Sale", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
