using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Data.Migrations
{
    public partial class AddedSeedUserAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Guid", "Email", "PasswordHash", "Username" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000001"), "IsaacAlger@gmail.com", "TestHash", "IsaacAlger" });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "Guid", "Email", "PasswordHash", "Username" },
                values: new object[] { new Guid("20000000-0000-0000-0000-000000000002"), "IsaacAlger2@gmail.com", "TestHash2", "IsaacAlger2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Guid",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "Guid",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));
        }
    }
}
