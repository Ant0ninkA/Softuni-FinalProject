using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyfyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 21, 14, 22, 656, DateTimeKind.Utc).AddTicks(3177));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 21, 14, 22, 656, DateTimeKind.Utc).AddTicks(3193));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DJ" },
                values: new object[] { new DateTime(2024, 11, 18, 21, 14, 22, 656, DateTimeKind.Utc).AddTicks(3197), "Groky" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventId", "Price", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { new Guid("1a54568e-a4b1-429c-86de-60a03197890b"), 2, 50.0m, 30, 1 },
                    { new Guid("3f279e50-e5f8-44fc-9359-3213f3400b40"), 1, 20.0m, 400, 2 },
                    { new Guid("80a13561-4c88-45fd-b5a4-0dd45e3df36b"), 3, 50.0m, 200, 2 },
                    { new Guid("9c2937be-c506-48b5-a175-1040fb516cc8"), 3, 20.0m, 200, 3 },
                    { new Guid("c1a1692a-6940-4531-af24-7228836a6327"), 2, 30.0m, 100, 2 },
                    { new Guid("dffcdfb8-7223-42f4-a1cd-e70f9cc3214e"), 3, 80.0m, 45, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1a54568e-a4b1-429c-86de-60a03197890b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("3f279e50-e5f8-44fc-9359-3213f3400b40"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("80a13561-4c88-45fd-b5a4-0dd45e3df36b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("9c2937be-c506-48b5-a175-1040fb516cc8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("c1a1692a-6940-4531-af24-7228836a6327"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("dffcdfb8-7223-42f4-a1cd-e70f9cc3214e"));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DJ" },
                values: new object[] { new DateTime(2024, 9, 25, 11, 8, 5, 866, DateTimeKind.Utc).AddTicks(9078), "Dimitar Georgiev - Groky" });

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
    }
}
