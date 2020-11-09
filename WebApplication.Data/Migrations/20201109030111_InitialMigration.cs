using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Guid);
                });

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
            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
