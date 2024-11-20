using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PartyfyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedOn",
                value: new DateTime(2024, 11, 18, 21, 14, 22, 656, DateTimeKind.Utc).AddTicks(3197));

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
    }
}
