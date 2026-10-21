using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDetailingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "admin-role", "admin-role-stamp", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin-user", 0, "admin-concurrency-stamp", "admin@autodetailingstudio.com", true, "System", "Administrator", false, null, "ADMIN@AUTODETAILINGSTUDIO.COM", "ADMIN@AUTODETAILINGSTUDIO.COM", "AQAAAAIAAYagAAAAECj4mF/MvU2l4sPYabNt6j/1+dfZtBSSs7zbcAmBf47xv1a1uvkb56ixiuOuXppU8Q==", null, false, "admin-security-stamp", false, "admin@autodetailingstudio.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin-role", "admin-user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin-role", "admin-user" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin-role");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user");
        }
    }
}
