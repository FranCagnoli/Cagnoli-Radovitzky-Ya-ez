﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinTur.DataAccess.Contexts;

namespace MinTur.DataAccess.Migrations
{
    [DbContext(typeof(NaturalUruguayContext))]
    partial class NaturalUruguayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.AuthorizationToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidSince")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("AuthorizationTokens");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.ElectricChargingPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("ElectricChargingPoints");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.GuestGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("GuestGroupType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("GuestGroups");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<int?>("ResortId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccommodationId")
                        .HasColumnType("int");

                    b.Property<int>("ActualStateId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResortId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.HasIndex("ActualStateId");

                    b.HasIndex("ResortId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.ReservationState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReservationStates");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Resort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MemberSince")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerNight")
                        .HasColumnType("int");

                    b.Property<double>("Punctuation")
                        .HasColumnType("float");

                    b.Property<string>("ReservationMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<int>("TouristPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TouristPointId");

                    b.ToTable("Resorts");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ResortId")
                        .HasColumnType("int");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.TouristPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("RegionId");

                    b.ToTable("TouristPoints");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.TouristPointCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TouristPointId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TouristPointId");

                    b.HasIndex("CategoryId", "TouristPointId")
                        .IsUnique();

                    b.ToTable("TouristPointCategories");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.AuthorizationToken", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Administrator", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.ElectricChargingPoint", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.GuestGroup", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Accommodation", null)
                        .WithMany("Guests")
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Image", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Resort", null)
                        .WithMany("Images")
                        .HasForeignKey("ResortId");
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Reservation", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinTur.Domain.BusinessEntities.ReservationState", "ActualState")
                        .WithMany()
                        .HasForeignKey("ActualStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinTur.Domain.BusinessEntities.Resort", "Resort")
                        .WithMany("Reservations")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Resort", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.TouristPoint", "TouristPoint")
                        .WithMany("Resorts")
                        .HasForeignKey("TouristPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.Review", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Resort", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ResortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.TouristPoint", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinTur.Domain.BusinessEntities.Region", "Region")
                        .WithMany("TouristPoints")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MinTur.Domain.BusinessEntities.TouristPointCategory", b =>
                {
                    b.HasOne("MinTur.Domain.BusinessEntities.Category", "Category")
                        .WithMany("TouristPointCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinTur.Domain.BusinessEntities.TouristPoint", "TouristPoint")
                        .WithMany("TouristPointCategory")
                        .HasForeignKey("TouristPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
