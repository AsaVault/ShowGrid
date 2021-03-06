﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShowGrid.Data;

namespace ShowGrid.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200901200905_ChangesToMoodel")]
    partial class ChangesToMoodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShowGrid.Models.UploadList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UploadList");
                });

            modelBuilder.Entity("ShowGrid.Models.UploadUser", b =>
                {
                    b.Property<int>("UploadUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UploadUserId");

                    b.ToTable("UploadUser");
                });

            modelBuilder.Entity("ShowGrid.Models.UserUpload", b =>
                {
                    b.Property<int>("UserUploadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UploadUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UploadUserId1")
                        .HasColumnType("int");

                    b.HasKey("UserUploadId");

                    b.HasIndex("UploadUserId1");

                    b.ToTable("UserUpload");
                });

            modelBuilder.Entity("ShowGrid.Models.UserUpload", b =>
                {
                    b.HasOne("ShowGrid.Models.UploadUser", "UploadUser")
                        .WithMany("UserUploads")
                        .HasForeignKey("UploadUserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
