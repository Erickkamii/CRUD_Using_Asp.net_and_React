﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Modelos;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(ProdutoContexto))]
    [Migration("20241122004428_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("back.Modelos.Produto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("precoCusto")
                        .HasColumnType("int");

                    b.Property<int?>("precoVenda")
                        .HasColumnType("int");

                    b.Property<int?>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
