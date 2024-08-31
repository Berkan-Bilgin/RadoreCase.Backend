using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatService.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ChatMessages",
                columns: new[] { "Id", "Message", "RoomName", "Timestamp", "UserName" },
                values: new object[,]
                {
                    { 1, "Hoş geldiniz! Burada her türlü soru ve sorunlarınızı paylaşabilirsiniz.", "Room-1", new DateTime(2024, 8, 31, 17, 0, 34, 398, DateTimeKind.Local).AddTicks(6374), "Admin" },
                    { 2, "Teşekkürler! Bu gerçekten harika bir özellik.", "Room-1", new DateTime(2024, 8, 31, 17, 0, 34, 398, DateTimeKind.Local).AddTicks(6384), "User1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");
        }
    }
}
