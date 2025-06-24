using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotemPWA.Migrations
{
    /// <inheritdoc />
    public partial class FotoIng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Ingredients",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "https://purepng.com/public/uploads/large/purepng.com-baconfood-meat-fried-pork-cooked-941524619205lmptp.png");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "https://www.pngmart.com/files/16/Cheese-Piece-Slice-PNG-Clipart.png");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "https://th.bing.com/th/id/R.e8b9516fa28fb9bd627f165702a56d6e?rik=hLa5GIL15ybojw&pid=ImgRaw&r=0");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "https://th.bing.com/th/id/R.0e88ac13dc38fd380591cf4dc357f709?rik=bigMcONgbIcfTA&riu=http%3a%2f%2fwww.pngall.com%2fwp-content%2fuploads%2f2016%2f04%2fTomato-Free-PNG-Image.png&ehk=TnfBtAyfzAetFPKm1B71hlBLCWT%2fIOfh961OOEmsejg%3d&risl=&pid=ImgRaw&r=0");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5,
                column: "Foto",
                value: "https://laretofood.hr/wp-content/uploads/2024/04/ROUNDEES-deciso-industria-min-600x600.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Ingredients");
        }
    }
}
