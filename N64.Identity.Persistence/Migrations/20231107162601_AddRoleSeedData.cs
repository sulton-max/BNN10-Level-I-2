using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N64.Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedTime", "IsDisabled", "ModifiedTime", "Type" },
                values: new object[,]
                {
                    { new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"), new DateTime(2023, 11, 7, 16, 26, 1, 261, DateTimeKind.Utc).AddTicks(9133), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"), new DateTime(2023, 11, 7, 16, 26, 1, 261, DateTimeKind.Utc).AddTicks(9138), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"), new DateTime(2023, 11, 7, 16, 26, 1, 261, DateTimeKind.Utc).AddTicks(9140), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Type",
                table: "Roles",
                column: "Type",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Roles_Type",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"));
        }
    }
}
