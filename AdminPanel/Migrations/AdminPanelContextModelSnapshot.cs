﻿// <auto-generated />
using System;
using AdminPanel.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminPanel.Migrations
{
    [DbContext(typeof(AdminPanelContext))]
    partial class AdminPanelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdminPanel.Entities.BlogKategorileri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Durum")
                        .HasColumnType("int");

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UstKategoriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UstKategoriId");

                    b.ToTable("BlogKategorileri");
                });

            modelBuilder.Entity("AdminPanel.Entities.Bloglar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Durum")
                        .HasColumnType("int");

                    b.Property<string>("Icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriId")
                        .HasColumnType("int");

                    b.Property<string>("KisaAciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KategoriId");

                    b.ToTable("Bloglar");
                });

            modelBuilder.Entity("AdminPanel.Entities.BlogKategorileri", b =>
                {
                    b.HasOne("AdminPanel.Entities.BlogKategorileri", "BlogKategori")
                        .WithMany()
                        .HasForeignKey("UstKategoriId");

                    b.Navigation("BlogKategori");
                });

            modelBuilder.Entity("AdminPanel.Entities.Bloglar", b =>
                {
                    b.HasOne("AdminPanel.Entities.BlogKategorileri", "BlogKategori")
                        .WithMany("Bloglar")
                        .HasForeignKey("KategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogKategori");
                });

            modelBuilder.Entity("AdminPanel.Entities.BlogKategorileri", b =>
                {
                    b.Navigation("Bloglar");
                });
#pragma warning restore 612, 618
        }
    }
}