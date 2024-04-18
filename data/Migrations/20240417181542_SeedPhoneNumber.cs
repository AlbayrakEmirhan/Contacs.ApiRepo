using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Api.data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 1,
                column: "phoneNumberName",
                value: "5537622553");

            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 2,
                column: "phoneNumberName",
                value: "5537622525");

            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 3,
                column: "phoneNumberName",
                value: "5537522553");

            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 4,
                column: "phoneNumberName",
                value: "5587622553");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 1,
                column: "phoneNumberName",
                value: null);

            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 2,
                column: "phoneNumberName",
                value: null);

            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 3,
                column: "phoneNumberName",
                value: null);

            migrationBuilder.UpdateData(
                table: "numbers",
                keyColumn: "Id",
                keyValue: 4,
                column: "phoneNumberName",
                value: null);
        }
    }
}
