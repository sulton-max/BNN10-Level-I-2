using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N64.Identity.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 7, 16, 27, 58, 653, DateTimeKind.Utc).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 7, 16, 27, 58, 653, DateTimeKind.Utc).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 7, 16, 27, 58, 653, DateTimeKind.Utc).AddTicks(7534));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("cefdf4ea-215b-45cb-8069-40455d1c8336"), 0, "", "Admin", true, "Admin", "", new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cefdf4ea-215b-45cb-8069-40455d1c8336"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 7, 16, 26, 1, 261, DateTimeKind.Utc).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 7, 16, 26, 1, 261, DateTimeKind.Utc).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 7, 16, 26, 1, 261, DateTimeKind.Utc).AddTicks(9140));
        }
    }
}
