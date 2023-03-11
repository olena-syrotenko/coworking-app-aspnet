﻿// <auto-generated />
using CoworkingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoworkingApp.Migrations
{
    [DbContext(typeof(AppDbContent))]
    [Migration("20230311151327_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("CoworkingApp.Data.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("area")
                        .HasColumnType("double");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("imageUrl")
                        .HasColumnType("longtext");

                    b.Property<int>("maxPlaces")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

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

            modelBuilder.Entity("CoworkingApp.Data.Models.Tariff", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("pricePerUnit")
                        .HasColumnType("double");

                    b.Property<int>("roomId")
                        .HasColumnType("int");

                    b.Property<int>("timeUnitId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("roomId");

                    b.HasIndex("timeUnitId");

                    b.ToTable("Tariff");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.TimeUnit", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("TimeUnit");
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

            modelBuilder.Entity("CoworkingApp.Data.Models.Room", b =>
                {
                    b.HasOne("CoworkingApp.Data.Models.RoomType", "roomType")
                        .WithMany("rooms")
                        .HasForeignKey("roomTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roomType");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.Tariff", b =>
                {
                    b.HasOne("CoworkingApp.Data.Models.Room", null)
                        .WithMany("tariffs")
                        .HasForeignKey("roomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoworkingApp.Data.Models.TimeUnit", "timeUnit")
                        .WithMany("tariffs")
                        .HasForeignKey("timeUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("timeUnit");
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
                    b.Navigation("tariffs");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.RoomType", b =>
                {
                    b.Navigation("rooms");
                });

            modelBuilder.Entity("CoworkingApp.Data.Models.TimeUnit", b =>
                {
                    b.Navigation("tariffs");
                });
#pragma warning restore 612, 618
        }
    }
}
