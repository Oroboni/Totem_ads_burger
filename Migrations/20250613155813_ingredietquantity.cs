using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotemPWA.Migrations
{
    /// <inheritdoc />
    public partial class ingredietquantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Compositions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 1,
                column: "quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 2,
                column: "quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 3,
                column: "quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 4,
                column: "quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Compositions",
                keyColumn: "Id",
                keyValue: 5,
                column: "quantity",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Compositions");
        }
    }
}
