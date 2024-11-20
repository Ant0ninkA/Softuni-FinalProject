using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyfyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameBuyedTicketsToTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsBuyers_Tickets_BuyedTicketsId",
                table: "TicketsBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsBuyers",
                table: "TicketsBuyers");

            migrationBuilder.DropIndex(
                name: "IX_TicketsBuyers_BuyersId",
                table: "TicketsBuyers");

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("00eb2769-dd92-4eb7-9f74-e66ca3c8bcdf"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("2ed5a555-1e0f-436c-ae34-0e68100bad9f"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("4002da19-ef15-40f0-8c88-7cfd0423de1c"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("7de4d3d1-8711-4ea5-9e0f-5f1c55d64cf8"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("9672c3be-7b78-4b0b-bd2d-ad03a0ec31ec"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("a37df619-d35a-4e6a-b652-282ae3b4b83b"));

            migrationBuilder.RenameColumn(
                name: "BuyedTicketsId",
                table: "TicketsBuyers",
                newName: "TicketsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsBuyers",
                table: "TicketsBuyers",
                columns: new[] { "BuyersId", "TicketsId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_TicketsBuyers_TicketsId",
                table: "TicketsBuyers",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsBuyers_Tickets_TicketsId",
                table: "TicketsBuyers",
                column: "TicketsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketsBuyers_Tickets_TicketsId",
                table: "TicketsBuyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketsBuyers",
                table: "TicketsBuyers");

            migrationBuilder.DropIndex(
                name: "IX_TicketsBuyers_TicketsId",
                table: "TicketsBuyers");

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

            migrationBuilder.RenameColumn(
                name: "TicketsId",
                table: "TicketsBuyers",
                newName: "BuyedTicketsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketsBuyers",
                table: "TicketsBuyers",
                columns: new[] { "BuyedTicketsId", "BuyersId" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 19, 13, 39, 55, 25, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 19, 13, 39, 55, 25, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 19, 13, 39, 55, 25, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "EventId", "Price", "Quantity", "TicketTypeId" },
                values: new object[,]
                {
                    { new Guid("00eb2769-dd92-4eb7-9f74-e66ca3c8bcdf"), 1, 20.0m, 400, 2 },
                    { new Guid("2ed5a555-1e0f-436c-ae34-0e68100bad9f"), 3, 50.0m, 200, 2 },
                    { new Guid("4002da19-ef15-40f0-8c88-7cfd0423de1c"), 3, 20.0m, 200, 3 },
                    { new Guid("7de4d3d1-8711-4ea5-9e0f-5f1c55d64cf8"), 2, 30.0m, 100, 2 },
                    { new Guid("9672c3be-7b78-4b0b-bd2d-ad03a0ec31ec"), 2, 50.0m, 30, 1 },
                    { new Guid("a37df619-d35a-4e6a-b652-282ae3b4b83b"), 3, 80.0m, 45, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketsBuyers_BuyersId",
                table: "TicketsBuyers",
                column: "BuyersId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketsBuyers_Tickets_BuyedTicketsId",
                table: "TicketsBuyers",
                column: "BuyedTicketsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
