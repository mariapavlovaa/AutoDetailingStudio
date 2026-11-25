using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDetailingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixSubscriptionSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiscountPercent",
                value: 0.05m);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiscountPercent",
                value: 0.10m);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DiscountPercent",
                value: 0.20m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiscountPercent",
                value: 5.00m);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiscountPercent",
                value: 10.00m);

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3,
                column: "DiscountPercent",
                value: 20.00m);
        }
    }
}
