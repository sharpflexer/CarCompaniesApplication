using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarCompaniesApplication.DAL.Migrations;

/// <inheritdoc />
public partial class SeedMockData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        var vwGroupId = new Guid("11111111-1111-1111-1111-111111111111");
        var toyotaGroupId = new Guid("22222222-2222-2222-2222-222222222222");

        migrationBuilder.InsertData(
            table: "CarCompanies",
            columns: new[] { "Id", "Name", "Site", "Description" },
            values: new object[,]
            {
        { toyotaGroupId, "Toyota Motor Corporation", "https://www.toyota-global.com", "Крупнейший японский производитель автомобилей" },
        { vwGroupId,     "Volkswagen Group",         "https://www.volkswagenag.com",  "Немецкий автомобильный концерн, владеющий множеством брендов" }
            });

        migrationBuilder.InsertData(
            table: "CarBrands",
            columns: new[] { "Id", "Name", "CompanyId", "Description" },
            values: new object[,]
            {
        { new Guid("33333333-3333-3333-3333-333333333333"), "Toyota", toyotaGroupId, "Основной бренд Toyota Motor Corporation" },
        { new Guid("44444444-4444-4444-4444-444444444444"), "Lexus",  toyotaGroupId, "Премиальный бренд Toyota" },
        { new Guid("55555555-5555-5555-5555-555555555555"), "Volkswagen", vwGroupId, "Основной бренд концерна Volkswagen" },
        { new Guid("66666666-6666-6666-6666-666666666666"), "Audi",    vwGroupId,    "Премиальный бренд концерна Volkswagen" }
            });

    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "CarBrands",
            keyColumn: "Id",
            keyValues: new object[]
            {
                new Guid("33333333-3333-3333-3333-333333333333"),
                new Guid("44444444-4444-4444-4444-444444444444"),
                new Guid("55555555-5555-5555-5555-555555555555"),
                new Guid("66666666-6666-6666-6666-666666666666")
            });

        migrationBuilder.DeleteData(
            table: "CarCompanies",
            keyColumn: "Id",
            keyValues: new object[]
            {
                new Guid("11111111-1111-1111-1111-111111111111"),
                new Guid("22222222-2222-2222-2222-222222222222")
            });
    }
}
