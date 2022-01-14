﻿// <auto-generated />
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelListing.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelListing.Models.Entities.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Contries");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Jamaica",
                            shortName = "JM"
                        },
                        new
                        {
                            id = 2,
                            name = "Bahamas",
                            shortName = "BS"
                        },
                        new
                        {
                            id = 3,
                            name = "Cayman Islan",
                            shortName = "CI"
                        });
                });

            modelBuilder.Entity("HotelListing.Models.Entities.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("rating")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("countryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            id = 1,
                            address = "Negril",
                            countryId = 1,
                            name = "Sandals Resort and Spa",
                            rating = 4.5
                        },
                        new
                        {
                            id = 2,
                            address = "George Town",
                            countryId = 3,
                            name = "Comfort Suites",
                            rating = 4.2999999999999998
                        },
                        new
                        {
                            id = 3,
                            address = "Nassua",
                            countryId = 2,
                            name = "Grand Palldium",
                            rating = 4.0
                        });
                });

            modelBuilder.Entity("HotelListing.Models.Entities.Hotel", b =>
                {
                    b.HasOne("HotelListing.Models.Entities.Country", "country")
                        .WithMany()
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });
#pragma warning restore 612, 618
        }
    }
}
