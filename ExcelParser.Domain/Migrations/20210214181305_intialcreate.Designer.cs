﻿// <auto-generated />
using System;
using ExcelParser.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExcelParser.Domain.Migrations
{
    [DbContext(typeof(SpreadsheetDbContext))]
    [Migration("20210214181305_intialcreate")]
    partial class intialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ExcelParser.Domain.Entities.Row", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Between_Att")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Between_Att");

                    b.Property<decimal?>("Between_Hi")
                        .HasColumnType("decimal(10,4)")
                        .HasColumnName("Between_Hi");

                    b.Property<decimal?>("Between_Lo")
                        .HasColumnType("decimal(10,4)")
                        .HasColumnName("Between_Lo");

                    b.Property<string>("Contains_Att")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Contains_Att");

                    b.Property<string>("Contains_Val")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Contains_Val");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Hie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Hie");

                    b.Property<int>("IDX")
                        .HasColumnType("int")
                        .HasColumnName("IDX");

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("Level");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Method");

                    b.Property<string>("Node")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Node");

                    b.Property<string>("Parent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Parent");

                    b.HasKey("Id");

                    b.ToTable("Spreadsheet");
                });
#pragma warning restore 612, 618
        }
    }
}
