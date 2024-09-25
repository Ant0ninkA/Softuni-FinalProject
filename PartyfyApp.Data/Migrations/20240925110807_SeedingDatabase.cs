using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyfyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Techno" },
                    { 2, "Rap" },
                    { 3, "Pop-folk" },
                    { 4, "Winamp" },
                    { 5, "Latino" }
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "VIP" },
                    { 2, "Standart" },
                    { 3, "Standing" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "DJ", "Description", "EventDate", "HosterId", "Location", "PosterImagePath", "Status", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9049), "COZTOF", "This season is centred around what we want to see more, it's all about the deep connection with the subconscious and the city that made us, the true urban jungle that we all want to be part of each and every week!", new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0d62abeb-9bf6-4ef1-b428-2712ccccdd29"), "EXE club, Sofia", "~/images/EXE CLUB.png", false, "EXE season 7 OPENING", null },
                    { 2, 5, new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9072), "Pandora MC Bram", "Feel the heat with the best Latin music, from sensual salsa to reggaeton beats that will keep you dancing all night long. Whether you're a seasoned dancer or just looking to have a great time, our DJ will spin the hottest tracks to make sure the energy never stops!", new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0d62abeb-9bf6-4ef1-b428-2712ccccdd29"), "Hacienda canteen, Sofia", "~/images/Ladies Night.png", false, "Ladies night", null },
                    { 3, 1, new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9078), "Groky", "Our world-class DJ lineup will take you on an intense sonic journey with hard-hitting bass, hypnotic melodies, and deep, driving rhythms that will make you lose yourself on the dance floor. This is where the music speaks, and the crowd moves as one.", new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0d62abeb-9bf6-4ef1-b428-2712ccccdd29"), "Yalta club, Sofia", "~/images/Techno Rave.png", false, "Les Machines with Commissar Lag", null }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventId", "Price", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { new Guid("22ba6eeb-b9fb-4335-aab4-7a2de2295dd8"), 3, 80.0m, 45, 1 },
                    { new Guid("295ecf74-1900-4180-acaf-4ec6b5e39f8e"), 2, 50.0m, 30, 1 },
                    { new Guid("488da7e1-c767-4a08-a874-1aa40480aa6f"), 2, 30.0m, 100, 2 },
                    { new Guid("867e1eed-3341-48c4-ad36-06628d6435d4"), 3, 50.0m, 200, 2 },
                    { new Guid("c71b25d8-7828-45eb-9340-26f7908bcaa1"), 1, 20.0m, 400, 2 },
                    { new Guid("f68b9d7f-001a-4253-9591-c3dd9c963e93"), 3, 20.0m, 200, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("22ba6eeb-b9fb-4335-aab4-7a2de2295dd8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("295ecf74-1900-4180-acaf-4ec6b5e39f8e"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("488da7e1-c767-4a08-a874-1aa40480aa6f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("867e1eed-3341-48c4-ad36-06628d6435d4"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("c71b25d8-7828-45eb-9340-26f7908bcaa1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f68b9d7f-001a-4253-9591-c3dd9c963e93"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
