﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZXB22RE45YGHB27.Data;

#nullable disable

namespace ZXB22RE45YGHB27.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230322123913_morecolumns")]
    partial class morecolumns
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZXB22RE45YGHB27.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("City")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Role")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ZXB22RE45YGHB27.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProjectName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Stop")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ZXB22RE45YGHB27.Models.ProjectList", b =>
                {
                    b.Property<int>("ProjectListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectListId"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FK_EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FK_ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Stop")
                        .HasColumnType("datetime2");

                    b.HasKey("ProjectListId");

                    b.HasIndex("FK_EmployeeId");

                    b.HasIndex("FK_ProjectId");

                    b.ToTable("ProjectLists");
                });

            modelBuilder.Entity("ZXB22RE45YGHB27.Models.ProjectList", b =>
                {
                    b.HasOne("ZXB22RE45YGHB27.Models.Employee", "Employees")
                        .WithMany("ProjectLists")
                        .HasForeignKey("FK_EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZXB22RE45YGHB27.Models.Project", "Projects")
                        .WithMany("ProjectLists")
                        .HasForeignKey("FK_ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ZXB22RE45YGHB27.Models.Employee", b =>
                {
                    b.Navigation("ProjectLists");
                });

            modelBuilder.Entity("ZXB22RE45YGHB27.Models.Project", b =>
                {
                    b.Navigation("ProjectLists");
                });
#pragma warning restore 612, 618
        }
    }
}
