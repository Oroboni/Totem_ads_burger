using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TotemPWA.Migrations
{
    /// <inheritdoc />
    public partial class newcombos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxQuantity", "quantity" },
                values: new object[] { 5, 2 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxQuantity", "quantity" },
                values: new object[] { 5, 3 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IngredientId", "MaxQuantity", "ProductId", "quantity" },
                values: new object[] { 5, 5, 1, 2 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IngredientId", "MaxQuantity", "ProductId", "quantity" },
                values: new object[] { 3, 5, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IngredientId", "MaxQuantity", "ProductId", "quantity" },
                values: new object[] { 1, 5, 2, 3 });

            migrationBuilder.InsertData(
                table: "Compositions",
                columns: new[] { "Id", "IngredientId", "IngredientId1", "MaxQuantity", "Nome", "PrecoAdicional", "ProductId", "quantity" },
                values: new object[,]
                {
                    { 6, 2, null, 5, "", 0m, 2, 2 },
                    { 7, 5, null, 5, "", 0m, 2, 2 },
                    { 8, 4, null, 5, "", 0m, 2, 1 },
                    { 9, 2, null, 5, "", 0m, 3, 3 },
                    { 10, 5, null, 5, "", 0m, 3, 3 },
                    { 11, 1, null, 5, "", 0m, 3, 1 },
                    { 12, 3, null, 5, "", 0m, 3, 1 },
                    { 13, 2, null, 5, "", 0m, 4, 4 },
                    { 14, 5, null, 5, "", 0m, 4, 2 },
                    { 15, 1, null, 5, "", 0m, 4, 2 },
                    { 16, 4, null, 5, "", 0m, 4, 1 },
                    { 17, 3, null, 5, "", 0m, 5, 3 },
                    { 18, 4, null, 5, "", 0m, 5, 2 },
                    { 19, 2, null, 5, "", 0m, 5, 1 },
                    { 20, 5, null, 5, "", 0m, 5, 2 },
                    { 21, 2, null, 5, "", 0m, 6, 3 },
                    { 22, 5, null, 5, "", 0m, 6, 2 },
                    { 23, 3, null, 5, "", 0m, 6, 1 },
                    { 24, 4, null, 5, "", 0m, 6, 2 },
                    { 25, 2, null, 5, "", 0m, 7, 2 },
                    { 26, 3, null, 5, "", 0m, 7, 2 },
                    { 27, 4, null, 5, "", 0m, 7, 1 },
                    { 28, 5, null, 5, "", 0m, 7, 3 },
                    { 29, 1, null, 5, "", 0m, 8, 2 },
                    { 30, 2, null, 5, "", 0m, 8, 2 },
                    { 31, 3, null, 5, "", 0m, 8, 1 },
                    { 32, 5, null, 5, "", 0m, 8, 3 },
                    { 33, 5, null, 5, "", 0m, 9, 2 },
                    { 34, 2, null, 5, "", 0m, 9, 2 },
                    { 35, 3, null, 5, "", 0m, 9, 2 },
                    { 36, 4, null, 5, "", 0m, 9, 1 },
                    { 37, 1, null, 5, "", 0m, 10, 2 },
                    { 38, 2, null, 5, "", 0m, 10, 2 },
                    { 39, 3, null, 5, "", 0m, 10, 2 },
                    { 40, 4, null, 5, "", 0m, 10, 1 },
                    { 41, 5, null, 5, "", 0m, 10, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaxQuantity", "quantity" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "MaxQuantity", "quantity" },
                values: new object[] { 1, 0 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IngredientId", "MaxQuantity", "ProductId", "quantity" },
                values: new object[] { 3, 1, 2, 0 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IngredientId", "MaxQuantity", "ProductId", "quantity" },
                values: new object[] { 4, 1, 2, 0 });

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IngredientId", "MaxQuantity", "ProductId", "quantity" },
                values: new object[] { 5, 1, 3, 0 });
        }
    }
}
