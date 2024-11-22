using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyfyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("6bee97c8-890b-4a9e-ac0b-3ef17c447b74"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("869d007d-04c4-4c1d-84d3-20f80806fa02"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a4f5a2e1-7ae5-4fc3-9019-9e07acdeb3dd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("add45df3-d88d-47b4-b526-ba683e078cf1"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("d3ac72e7-2c17-456c-aec1-0493395377e5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ec8ed61e-1de4-476d-907f-661ff6402f98"));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 21, 13, 19, 53, 970, DateTimeKind.Utc).AddTicks(5786));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 21, 13, 19, 53, 970, DateTimeKind.Utc).AddTicks(5812));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 21, 13, 19, 53, 970, DateTimeKind.Utc).AddTicks(5818));

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventId", "Price", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { new Guid("53f9db80-2ceb-473b-a1a4-23fc3442e11b"), 1, 20.0m, 400, 2 },
                    { new Guid("622ea59f-1ddf-45bd-85ff-171a30d0cbd8"), 2, 50.0m, 30, 1 },
                    { new Guid("9febf9f7-0f6f-4d68-83e8-8aca6a50ee68"), 3, 80.0m, 45, 1 },
                    { new Guid("a96e2d29-f9fa-4709-8cff-8e43c1af93df"), 3, 20.0m, 200, 3 },
                    { new Guid("c71ebc63-9361-4123-802a-4945ea2b7b12"), 2, 30.0m, 100, 2 },
                    { new Guid("fbfe273c-4c34-4360-a1d3-e9b44c89f66b"), 3, 50.0m, 200, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("53f9db80-2ceb-473b-a1a4-23fc3442e11b"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("622ea59f-1ddf-45bd-85ff-171a30d0cbd8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("9febf9f7-0f6f-4d68-83e8-8aca6a50ee68"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a96e2d29-f9fa-4709-8cff-8e43c1af93df"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("c71ebc63-9361-4123-802a-4945ea2b7b12"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("fbfe273c-4c34-4360-a1d3-e9b44c89f66b"));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 20, 15, 30, 51, 328, DateTimeKind.Utc).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 20, 15, 30, 51, 328, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 20, 15, 30, 51, 328, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventId", "Price", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { new Guid("6bee97c8-890b-4a9e-ac0b-3ef17c447b74"), 2, 30.0m, 100, 2 },
                    { new Guid("869d007d-04c4-4c1d-84d3-20f80806fa02"), 3, 20.0m, 200, 3 },
                    { new Guid("a4f5a2e1-7ae5-4fc3-9019-9e07acdeb3dd"), 2, 50.0m, 30, 1 },
                    { new Guid("add45df3-d88d-47b4-b526-ba683e078cf1"), 1, 20.0m, 400, 2 },
                    { new Guid("d3ac72e7-2c17-456c-aec1-0493395377e5"), 3, 80.0m, 45, 1 },
                    { new Guid("ec8ed61e-1de4-476d-907f-661ff6402f98"), 3, 50.0m, 200, 2 }
                });
        }
    }
}
