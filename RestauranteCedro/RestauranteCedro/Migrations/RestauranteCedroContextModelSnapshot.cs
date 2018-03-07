﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RestauranteCedro;
using System;

namespace RestauranteCedro.Migrations
{
    [DbContext(typeof(RestauranteCedroContext))]
    partial class RestauranteCedroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestauranteCedro.Entities.Prato", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnName("descricao");

                    b.Property<int>("idRestaurante")
                        .HasColumnName("idRestaurante");

                    b.Property<double>("preco")
                        .HasColumnName("preco");

                    b.HasKey("id");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("RestauranteCedro.Entities.Restaurante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnName("nome");

                    b.HasKey("id");

                    b.ToTable("Restaurante");
                });
#pragma warning restore 612, 618
        }
    }
}