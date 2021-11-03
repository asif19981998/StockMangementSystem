﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMS.DataBaseContext;

namespace SMS.DataBaseContext.Migrations
{
    [DbContext(typeof(SMSDbContext))]
    partial class SMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SMS.Models.District", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("DivisonId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DivisonId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "001Di",
                            DivisonId = 1L,
                            IsDeleted = false,
                            Name = "Kishoreganj"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "002Di",
                            DivisonId = 1L,
                            IsDeleted = false,
                            Name = "Gazipur"
                        },
                        new
                        {
                            Id = 3L,
                            Code = "003Di",
                            DivisonId = 1L,
                            IsDeleted = false,
                            Name = "Manikganj"
                        });
                });

            modelBuilder.Entity("SMS.Models.Divison", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Divisons");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "001D",
                            IsDeleted = false,
                            Name = "Dhaka"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "002D",
                            IsDeleted = false,
                            Name = "Khulna"
                        });
                });

            modelBuilder.Entity("SMS.Models.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SMS.Models.Stock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<long>("UpazilaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UpazilaId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("SMS.Models.Upazila", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("DistrictId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Upazilas");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Code = "001U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Kishoreganj Sadar"
                        },
                        new
                        {
                            Id = 2L,
                            Code = "002U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Bhairab"
                        },
                        new
                        {
                            Id = 3L,
                            Code = "003U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Bajitpur"
                        },
                        new
                        {
                            Id = 4L,
                            Code = "004U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Kuliarchar"
                        },
                        new
                        {
                            Id = 5L,
                            Code = "005U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Pakundia"
                        },
                        new
                        {
                            Id = 6L,
                            Code = "006U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Itna"
                        },
                        new
                        {
                            Id = 7L,
                            Code = "007U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Karimganj"
                        },
                        new
                        {
                            Id = 8L,
                            Code = "008U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Katiadi"
                        },
                        new
                        {
                            Id = 9L,
                            Code = "009U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Ashtagram"
                        },
                        new
                        {
                            Id = 10L,
                            Code = "0010U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Mithamin"
                        },
                        new
                        {
                            Id = 11L,
                            Code = "0011U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Tarail"
                        },
                        new
                        {
                            Id = 12L,
                            Code = "0012U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Hossainpur"
                        },
                        new
                        {
                            Id = 13L,
                            Code = "0013U",
                            DistrictId = 1L,
                            IsDeleted = false,
                            Name = "Nikli"
                        });
                });

            modelBuilder.Entity("SMS.Models.District", b =>
                {
                    b.HasOne("SMS.Models.Divison", "Divison")
                        .WithMany("Districts")
                        .HasForeignKey("DivisonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Divison");
                });

            modelBuilder.Entity("SMS.Models.Stock", b =>
                {
                    b.HasOne("SMS.Models.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SMS.Models.Upazila", "Upazila")
                        .WithMany("Stocks")
                        .HasForeignKey("UpazilaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Upazila");
                });

            modelBuilder.Entity("SMS.Models.Upazila", b =>
                {
                    b.HasOne("SMS.Models.District", "District")
                        .WithMany("Upazila")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("SMS.Models.District", b =>
                {
                    b.Navigation("Upazila");
                });

            modelBuilder.Entity("SMS.Models.Divison", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("SMS.Models.Product", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("SMS.Models.Upazila", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
