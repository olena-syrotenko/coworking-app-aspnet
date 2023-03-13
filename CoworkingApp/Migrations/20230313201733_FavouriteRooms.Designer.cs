﻿// <auto-generated />
using System;
using CoworkingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoworkingApp.Migrations
{
    [DbContext(typeof(AppDbContent))]
    [Migration("20230313201733_FavouriteRooms")]
    partial class FavouriteRooms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CoworkingApp.Data.Models.Place", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("longtext");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roomId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.RentCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("placeid")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<string>("rentCartId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("rentEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("rentStart")
                        .HasColumnType("datetime(6)");

                    b.HasKey("id");

                    b.HasIndex("placeid");

                    b.ToTable("RentCartItem");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("area")
                        .HasColumnType("double");

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext");

                    b.Property<bool>("isFavourite")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("maxPlaces")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<int>("roomTypeId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roomTypeId");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.RoomType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.Service", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("RoomService", b =>
                {
                    b.Property<int>("roomsid")
                        .HasColumnType("int");

                    b.Property<int>("servicesid")
                        .HasColumnType("int");

                    b.HasKey("roomsid", "servicesid");

                    b.HasIndex("servicesid");

                    b.ToTable("RoomService");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.Place", b =>
                {
                    b.HasOne("CoworkingApp.Data.Models.Room", "room")
                        .WithMany("places")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("room");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.RentCartItem", b =>
                {
                    b.HasOne("CoworkingApp.Data.Models.Place", "place")
                        .WithMany()
                        .HasForeignKey("placeid");

                    b.Navigation("place");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.Room", b =>
                {
                    b.HasOne("CoworkingApp.Data.Models.RoomType", "roomType")
                        .WithMany("rooms")
                        .HasForeignKey("roomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roomType");
                });

            modelBuilder.Entity("RoomService", b =>
                {
                    b.HasOne("CoworkingApp.Data.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("roomsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoworkingApp.Data.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("servicesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.Room", b =>
                {
                    b.Navigation("places");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.RoomType", b =>
                {
                    b.Navigation("rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
