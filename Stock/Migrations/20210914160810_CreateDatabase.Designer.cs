﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stock.Data;

namespace Stock.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210914160810_CreateDatabase")]
    partial class CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stock.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kurs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Walor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Zmiana")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Stock.Models.Observed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CenaZakupu")
                        .HasColumnType("real");

                    b.Property<int>("LiczbaAkcji")
                        .HasColumnType("int");

                    b.Property<string>("Walor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Observed");
                });
#pragma warning restore 612, 618
        }
    }
}