using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameTracker.Migrations
{
    /// <inheritdoc />
    public partial class fixedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c677942-f0a3-43cb-9c9c-e24ae8432732");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2219c249-b553-42a6-a3ea-c720e72b228e");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "character varying(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "645d8744-06ba-4f15-ac81-53f329f7ab5b", null, "AppRole", "Admin", "ADMIN" },
                    { "dd37030e-972a-4f79-9abc-d09bf4208a98", null, "AppRole", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "645d8744-06ba-4f15-ac81-53f329f7ab5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd37030e-972a-4f79-9abc-d09bf4208a98");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c677942-f0a3-43cb-9c9c-e24ae8432732", null, "Admin", "ADMIN" },
                    { "2219c249-b553-42a6-a3ea-c720e72b228e", null, "User", "USER" }
                });
        }
    }
}
