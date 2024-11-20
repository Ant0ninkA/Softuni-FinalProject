using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyfyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFirstAndLastName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("02f15383-d8c6-45f7-b3a8-9d42e0fd7457"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("083d31e3-0b72-4817-b325-ef7dfd8590c9"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("1d1cea2c-f8bc-4f6a-a0f9-17aff431c1c0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5b410919-3bc9-443f-af28-9b373bc589b6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("7e95c2f1-50e6-4ff3-b4db-822ca154baf6"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("b81d7141-6c71-442c-9706-20977f4fbffa"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Testov");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 20, 13, 42, 0, 349, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 20, 13, 42, 0, 349, DateTimeKind.Utc).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 20, 13, 42, 0, 349, DateTimeKind.Utc).AddTicks(1683));

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventId", "Price", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { new Guid("02f15383-d8c6-45f7-b3a8-9d42e0fd7457"), 2, 30.0m, 100, 2 },
                    { new Guid("083d31e3-0b72-4817-b325-ef7dfd8590c9"), 3, 20.0m, 200, 3 },
                    { new Guid("1d1cea2c-f8bc-4f6a-a0f9-17aff431c1c0"), 2, 50.0m, 30, 1 },
                    { new Guid("5b410919-3bc9-443f-af28-9b373bc589b6"), 1, 20.0m, 400, 2 },
                    { new Guid("7e95c2f1-50e6-4ff3-b4db-822ca154baf6"), 3, 80.0m, 45, 1 },
                    { new Guid("b81d7141-6c71-442c-9706-20977f4fbffa"), 3, 50.0m, 200, 2 }
                });
        }
    }
}
