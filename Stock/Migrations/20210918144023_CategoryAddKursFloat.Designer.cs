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
    [Migration("20210918144023_CategoryAddKursFloat")]
    partial class CategoryAddKursFloat
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

                    b.Property<float>("KursFloat")
                        .HasColumnType("real");

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

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<float>("CenaZakupu")
                        .HasColumnType("real");

                    b.Property<int>("LiczbaAkcji")
                        .HasColumnType("int");

                    b.Property<string>("Walor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Zysk")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Observed");
                });

            modelBuilder.Entity("Stock.Models.Observed", b =>
                {
                    b.HasOne("Stock.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}