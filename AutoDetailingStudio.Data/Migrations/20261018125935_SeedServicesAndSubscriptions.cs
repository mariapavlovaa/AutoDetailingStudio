using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDetailingStudio.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedServicesAndSubscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "DurationMinutes", "ImageUrl", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Professional exterior wash, wheel cleaning and drying.", 30, "/images/exterior-wash.jpg", true, "Exterior Wash", 30.00m },
                    { 2, "Vacuuming, dashboard cleaning and interior surface treatment.", 60, "/images/interior-cleaning.jpg", true, "Interior Cleaning", 50.00m },
                    { 3, "Complete exterior and interior vehicle cleaning.", 90, "/images/full-car-wash.jpg", true, "Full Car Wash", 75.00m },
                    { 4, "Deep cleaning of seats, carpets and upholstery.", 180, "/images/interior-detailing.jpg", true, "Interior Detailing", 180.00m },
                    { 5, "Machine polishing to reduce scratches and restore paint gloss.", 300, "/images/paint-polishing.jpg", true, "Paint Polishing", 350.00m },
                    { 6, "Application of protective ceramic coating for long-lasting paint protection.", 480, "/images/ceramic-coating.jpg", true, "Ceramic Coating", 650.00m }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Description", "DiscountPercent", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Basic car care subscription with a 5% discount on all services.", 5.00m, true, "Basic", 29.99m },
                    { 2, "Premium car care subscription with a 10% discount on all services.", 10.00m, true, "Premium", 59.99m },
                    { 3, "VIP car care subscription with a 20% discount on all services.", 20.00m, true, "VIP", 99.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
