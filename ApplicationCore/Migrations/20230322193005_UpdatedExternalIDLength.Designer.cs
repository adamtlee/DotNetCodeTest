﻿// <auto-generated />
using System;
using ApplicationCore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApplicationCore.Migrations
{
    [DbContext(typeof(StraboContext))]
    [Migration("20230322193005_UpdatedExternalIDLength")]
    partial class UpdatedExternalIDLength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.DataModel.Price", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateOnly?>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("PriceTypeName")
                        .IsRequired()
                        .HasColumnType("character varying(20)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int?>("QuantityFrom")
                        .HasColumnType("integer");

                    b.Property<int?>("QuantityTo")
                        .HasColumnType("integer");

                    b.Property<DateOnly?>("ToDate")
                        .HasColumnType("date");

                    b.Property<string>("UnitOfMeasureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PriceTypeName");

                    b.HasIndex("UnitOfMeasureName");

                    b.HasIndex("ProductId", "PriceTypeName", "FromDate", "QuantityFrom");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("ApplicationCore.DataModel.PriceType", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.HasKey("Name");

                    b.ToTable("PriceTypes");
                });

            modelBuilder.Entity("ApplicationCore.DataModel.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("MinimumOrderQuantity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("ProductNumber")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("character varying(48)");

                    b.Property<string>("UnitOfMeasureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductNumber");

                    b.HasIndex("UnitOfMeasureName");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ApplicationCore.DataModel.UnitOfMeasure", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("ExternalId")
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.HasKey("Name");

                    b.ToTable("UnitsOfMeasure");
                });

            modelBuilder.Entity("ApplicationCore.DataModel.Price", b =>
                {
                    b.HasOne("ApplicationCore.DataModel.PriceType", "PriceType")
                        .WithMany()
                        .HasForeignKey("PriceTypeName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ApplicationCore.DataModel.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.DataModel.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasureName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PriceType");

                    b.Navigation("Product");

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("ApplicationCore.DataModel.Product", b =>
                {
                    b.HasOne("ApplicationCore.DataModel.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasureName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UnitOfMeasure");
                });
#pragma warning restore 612, 618
        }
    }
}
