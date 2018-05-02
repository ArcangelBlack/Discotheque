﻿// <auto-generated />
using D.Models.Enums;
using DiscothequeW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DiscothequeW.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("D.Models.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("IdRol");

                    b.Property<string>("Logo");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int?>("RolId");

                    b.Property<string>("Ruc")
                        .IsRequired();

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("AppCompanies");
                });

            modelBuilder.Entity("D.Models.Models.Discotheque", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Cp");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook")
                        .IsRequired();

                    b.Property<int>("IdCompany");

                    b.Property<double>("Latitud");

                    b.Property<string>("Logo");

                    b.Property<double>("Longitud");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("WebSite")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("AppDiscotheques");
                });

            modelBuilder.Entity("D.Models.Models.DiscothequeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("AppDiscothequeCategories");
                });

            modelBuilder.Entity("D.Models.Models.DiscothequeDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DiscothequeCategoryId");

                    b.Property<int?>("DiscothequeId");

                    b.Property<int>("IdDiscotheque");

                    b.Property<int>("IdDiscothequeCategory");

                    b.HasKey("Id");

                    b.HasIndex("DiscothequeCategoryId");

                    b.HasIndex("DiscothequeId");

                    b.ToTable("AppDiscothequeDetails");
                });

            modelBuilder.Entity("D.Models.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<int>("Gender");

                    b.Property<int>("IdRol");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int?>("RolId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("AppEmployees");
                });

            modelBuilder.Entity("D.Models.Models.Music", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<int>("IdCustomer");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AppMusics");
                });

            modelBuilder.Entity("D.Models.Models.MusicDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("DiscothequeId");

                    b.Property<decimal>("Discount");

                    b.Property<int>("IdDiscotheque");

                    b.Property<int>("IdMusic");

                    b.Property<int?>("MusicId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("DiscothequeId");

                    b.HasIndex("MusicId");

                    b.ToTable("AppMusicDetails");
                });

            modelBuilder.Entity("D.Models.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("AppRols");
                });

            modelBuilder.Entity("D.Models.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<int>("IdRol");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<int?>("RolId");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(256);

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("D.Models.Models.Company", b =>
                {
                    b.HasOne("D.Models.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("D.Models.Models.Discotheque", b =>
                {
                    b.HasOne("D.Models.Models.Company")
                        .WithMany("Discotheques")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("D.Models.Models.DiscothequeDetail", b =>
                {
                    b.HasOne("D.Models.Models.DiscothequeCategory", "DiscothequeCategory")
                        .WithMany()
                        .HasForeignKey("DiscothequeCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("D.Models.Models.Discotheque", "Discotheque")
                        .WithMany("DiscothequeDetails")
                        .HasForeignKey("DiscothequeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("D.Models.Models.Employee", b =>
                {
                    b.HasOne("D.Models.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("D.Models.Models.Music", b =>
                {
                    b.HasOne("D.Models.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("D.Models.Models.MusicDetail", b =>
                {
                    b.HasOne("D.Models.Models.Discotheque", "Discotheque")
                        .WithMany()
                        .HasForeignKey("DiscothequeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("D.Models.Models.Music", "Music")
                        .WithMany("OrderDetails")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("D.Models.Models.User", b =>
                {
                    b.HasOne("D.Models.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}