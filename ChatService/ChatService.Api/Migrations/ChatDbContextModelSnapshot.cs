﻿// <auto-generated />
using System;
using ChatService.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChatService.Api.Migrations
{
    [DbContext(typeof(ChatDbContext))]
    partial class ChatDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatService.Api.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("ChatMessages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Message = "Hoş geldiniz! Burada her türlü soru ve sorunlarınızı paylaşabilirsiniz.",
                            RoomId = "Room-User2",
                            Timestamp = new DateTime(2024, 8, 31, 18, 11, 59, 889, DateTimeKind.Utc).AddTicks(1965),
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Message = "Teşekkürler! Bu gerçekten harika bir özellik.",
                            RoomId = "Room-User2",
                            Timestamp = new DateTime(2024, 8, 31, 18, 11, 59, 889, DateTimeKind.Utc).AddTicks(1967),
                            UserName = "User1"
                        });
                });

            modelBuilder.Entity("ChatService.Api.Models.Room", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = "Room-User1",
                            CreatedAt = new DateTime(2024, 8, 31, 18, 11, 59, 889, DateTimeKind.Utc).AddTicks(1827),
                            Name = "Room-User1"
                        },
                        new
                        {
                            Id = "Room-User2",
                            CreatedAt = new DateTime(2024, 8, 31, 18, 11, 59, 889, DateTimeKind.Utc).AddTicks(1830),
                            Name = "Room-User2"
                        });
                });

            modelBuilder.Entity("ChatService.Api.Models.ChatMessage", b =>
                {
                    b.HasOne("ChatService.Api.Models.Room", "Room")
                        .WithMany("ChatMessages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ChatService.Api.Models.Room", b =>
                {
                    b.Navigation("ChatMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
