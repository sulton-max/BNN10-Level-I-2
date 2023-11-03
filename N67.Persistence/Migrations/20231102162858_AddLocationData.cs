using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N67.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "ParentId", "Type" },
                values: new object[,]
                {
                    { new Guid("77589501-22b7-4fa2-9436-534c0c46913e"), "Uzbekistan", null, 0 },
                    { new Guid("33517080-5e99-4591-b85d-2ed1ebf3bd98"), "Tashkent", new Guid("77589501-22b7-4fa2-9436-534c0c46913e"), 1 },
                    { new Guid("5eccba7f-4361-4ee6-832f-35ab309786cd"), "Navoiy", new Guid("77589501-22b7-4fa2-9436-534c0c46913e"), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("33517080-5e99-4591-b85d-2ed1ebf3bd98"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("5eccba7f-4361-4ee6-832f-35ab309786cd"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("77589501-22b7-4fa2-9436-534c0c46913e"));
        }
    }
}
