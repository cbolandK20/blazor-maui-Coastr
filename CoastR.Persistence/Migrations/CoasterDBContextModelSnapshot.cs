﻿// <auto-generated />
using System;
using Coastr.Persistence.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoastR.Persistence.Migrations
{
    [DbContext(typeof(CoasterDBContext))]
    partial class CoasterDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("CoastR.Model.Bill", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sum")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("VenueName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BILLS", (string)null);
                });

            modelBuilder.Entity("CoastR.Model.BillItem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BillId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Sum")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.ToTable("BILL_ITEMS", (string)null);
                });

            modelBuilder.Entity("Coastr.Model.Coaster", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VenueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VenueId");

                    b.ToTable("COASTERS", (string)null);
                });

            modelBuilder.Entity("Coastr.Model.CoasterItem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CoasterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Index")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoasterId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("COASTER_ITEMS", (string)null);
                });

            modelBuilder.Entity("Coastr.Model.Menu", b =>
                {
                    b.Property<int?>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MENUES", (string)null);
                });

            modelBuilder.Entity("Coastr.Model.MenuItem", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MenuId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("MENU_ITEMS", (string)null);
                });

            modelBuilder.Entity("Coastr.Model.Venue", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VENUES", (string)null);
                });

            modelBuilder.Entity("CoastR.Model.Bill", b =>
                {
                    b.OwnsOne("CoastR.Model.GeoPosition", "VenueLocation", b1 =>
                        {
                            b1.Property<int>("BillId")
                                .HasColumnType("INTEGER");

                            b1.Property<double?>("Altitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Latitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Longitude")
                                .HasColumnType("REAL");

                            b1.HasKey("BillId");

                            b1.ToTable("BILLS");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("VenueLocation");
                });

            modelBuilder.Entity("CoastR.Model.BillItem", b =>
                {
                    b.HasOne("CoastR.Model.Bill", null)
                        .WithMany("Items")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Coastr.Model.Coaster", b =>
                {
                    b.HasOne("Coastr.Model.Venue", "Venue")
                        .WithMany()
                        .HasForeignKey("VenueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Coastr.Model.CoasterItem", b =>
                {
                    b.HasOne("Coastr.Model.Coaster", "Coaster")
                        .WithMany("Items")
                        .HasForeignKey("CoasterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Coastr.Model.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Coaster");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("Coastr.Model.Menu", b =>
                {
                    b.HasOne("Coastr.Model.Venue", "Venue")
                        .WithOne("Menu")
                        .HasForeignKey("Coastr.Model.Menu", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("Coastr.Model.MenuItem", b =>
                {
                    b.HasOne("Coastr.Model.Menu", "Menu")
                        .WithMany("Items")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Coastr.Model.Venue", b =>
                {
                    b.OwnsOne("CoastR.Model.GeoPosition", "Location", b1 =>
                        {
                            b1.Property<int>("VenueId")
                                .HasColumnType("INTEGER");

                            b1.Property<double?>("Altitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Latitude")
                                .HasColumnType("REAL");

                            b1.Property<double>("Longitude")
                                .HasColumnType("REAL");

                            b1.HasKey("VenueId");

                            b1.ToTable("VENUES");

                            b1.WithOwner()
                                .HasForeignKey("VenueId");
                        });

                    b.Navigation("Location");
                });

            modelBuilder.Entity("CoastR.Model.Bill", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Coastr.Model.Coaster", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Coastr.Model.Menu", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Coastr.Model.Venue", b =>
                {
                    b.Navigation("Menu");
                });
#pragma warning restore 612, 618
        }
    }
}
