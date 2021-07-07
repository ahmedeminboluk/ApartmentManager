using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentManager.Data.Migrations
{
    public partial class mig_add_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "600a7c55-6614-4607-b9ec-984f99a40bd8", "8843758e-31d0-4fac-8cd2-555921055b30", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9047da04-ffb9-42ff-bb56-921cbbc67b95", "09f6efc7-db89-44b1-8e5f-d3452483b809", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CarPlate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TcNo", "TwoFactorEnabled", "UserName" },
                values: new object[] { "95587827-f1ae-4bb1-b0b4-6777cf57ca07", 0, "34 AA 33", "ee6f5d33-2ebd-4c6f-bfa0-a3a5bc06653f", "admin@admin.com", false, "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEJtn5Wj6Wlnf8pRIy8SPh4dXCQ+OEQqSrQL5jR4nIp4OW1SvdDXCnpXKJZjo3LLLhw==", null, false, "9c9e5864-93f7-4c5b-8326-9d8a1f6d0302", "12345678911", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "600a7c55-6614-4607-b9ec-984f99a40bd8", "95587827-f1ae-4bb1-b0b4-6777cf57ca07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9047da04-ffb9-42ff-bb56-921cbbc67b95");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "600a7c55-6614-4607-b9ec-984f99a40bd8", "95587827-f1ae-4bb1-b0b4-6777cf57ca07" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "600a7c55-6614-4607-b9ec-984f99a40bd8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95587827-f1ae-4bb1-b0b4-6777cf57ca07");
        }
    }
}
