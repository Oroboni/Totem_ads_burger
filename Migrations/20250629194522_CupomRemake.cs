using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TotemPWA.Migrations
{
    /// <inheritdoc />
    public partial class CupomRemake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cupons",
                table: "Cupons");

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "Codigo",
                keyValue: "BLACKFRIDAY");

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "Codigo",
                keyValue: "NATAL2023");

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "Codigo",
                keyValue: "VERAO2023");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cupons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Cupons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cupons",
                table: "Cupons",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cupons",
                columns: new[] { "Id", "Codigo", "Desconto", "Type" },
                values: new object[,]
                {
                    { 1, "BLACKFRIDAY", 0.2m, 0 },
                    { 2, "NATAL2023", 0.15m, 0 },
                    { 3, "VERAO2023", 10.00m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cupons",
                table: "Cupons");

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cupons",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cupons");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Cupons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cupons",
                table: "Cupons",
                column: "Codigo");

            migrationBuilder.InsertData(
                table: "Cupons",
                columns: new[] { "Codigo", "Desconto" },
                values: new object[,]
                {
                    { "BLACKFRIDAY", 0.2m },
                    { "NATAL2023", 0.15m },
                    { "VERAO2023", 0.1m }
                });
        }
    }
}
