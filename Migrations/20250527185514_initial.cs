using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TotemPWA.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    AdditionalPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId", "Slug" },
                values: new object[,]
                {
                    { 1, "Burgers", null, "burgers" },
                    { 2, "Combos", null, "combos" },
                    { 3, "Bebidas", null, "bebidas" },
                    { 4, "Acompanhamentos", null, "acompanhamentos" },
                    { 5, "Molhos", null, "molhos" },
                    { 6, "Artesanais", 1, "artesanais" },
                    { 7, "Tradicionais", 1, "tradicionais" },
                    { 8, "Refrigerantes", 3, "refrigerantes" },
                    { 9, "Sucos", 3, "sucos" },
                    { 10, "Batatas", 4, "batatas" },
                    { 11, "Onion Rings", 4, "onion-rings" },
                    { 12, "Combos Premium", 2, "combos-premium" },
                    { 13, "Combos Familiares", 2, "combos-familiares" },
                    { 14, "Molhos Picantes", 5, "molhos-picantes" },
                    { 15, "Molhos Especiais", 5, "molhos-especiais" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Foto", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 6, "Pão brioche, blend artesanal, queijo cheddar", "burguerI.jpg", "Cheeseburger Artesanal", 18.99m },
                    { 2, 6, "Pão australiano, bacon crocante, cheddar derretido", "burguerII.jpg", "Bacon Cheddar", 21.99m },
                    { 3, 6, "Pão de parmesão, carne 180g, molho blue cheese", "burguerIII.jpg", "Blue Cheese Burger", 22.50m },
                    { 4, 6, "Pão pretzel, trufas, queijo gruyère", "buguer404.png", "Truffle Burger", 24.99m },
                    { 5, 6, "Pão integral, hambúrguer de grão-de-bico", "veggie.jpg", "Veggie Artesanal", 19.99m },
                    { 6, 7, "Pão, carne, queijo e molho especial", "veggie.jpg", "Cheeseburger Clássico", 15.99m },
                    { 7, 7, "Pão, carne, queijo, presunto e salada", "veggie.jpg", "X-Burger", 16.50m },
                    { 8, 7, "Pão, carne, queijo, bacon e salada", "veggie.jpg", "X-Bacon", 18.50m },
                    { 9, 7, "Pão, carne, queijo, ovo e salada", "veggie.jpg", "X-Egg", 17.50m },
                    { 10, 7, "Pão, 2 carnes, queijo, bacon, ovo e salada", "veggie.jpg", "X-Tudo", 20.99m },
                    { 11, 8, "350ml", "coca.webp", "Coca-Cola Lata", 6.00m },
                    { 12, 8, "350ml", "gurana.jpg", "Guaraná Antarctica", 5.50m },
                    { 13, 8, "350ml", "Fanta-Laranja.webp", "Fanta Laranja", 5.50m },
                    { 14, 8, "350ml", "sprite.webp", "Sprite", 5.50m },
                    { 15, 8, "Garrafa 600ml", "coca600.webp", "Coca-Cola 600ml", 8.00m },
                    { 16, 9, "Natural 500ml", "coca.webp", "Suco de Laranja", 10.00m },
                    { 17, 9, "Natural 500ml", "coca.webp", "Suco de Abacaxi", 10.00m },
                    { 18, 9, "Natural 500ml", "coca.webp", "Suco de Morango", 12.00m },
                    { 19, 9, "Natural 500ml", "coca.webp", "Suco de Maracujá", 12.00m },
                    { 20, 9, "Couve, abacaxi e gengibre 500ml", "coca.webp", "Suco Verde", 12.50m },
                    { 21, 10, "Porção pequena", "batata frita.jpg", "Batata Frita Pequena", 8.00m },
                    { 22, 10, "Porção média", "batata frita.jpg", "Batata Frita Média", 12.00m },
                    { 23, 10, "Porção grande", "batata frita.jpg", "Batata Frita Grande", 16.00m },
                    { 24, 10, "Porção média com cheddar e bacon", "batata frita.jpg", "Batata Cheddar e Bacon", 18.00m },
                    { 25, 10, "Porção média de batata doce", "batatadoce.webp", "Batata Doce", 14.00m },
                    { 26, 11, "Porção pequena", "batata frita.jpg", "Onion Rings Pequena", 10.00m },
                    { 27, 11, "Porção média", "batata frita.jpg", "Onion Rings Média", 14.00m },
                    { 28, 11, "Porção grande", "batata frita.jpg", "Onion Rings Grande", 18.00m },
                    { 29, 11, "Porção média com cheddar", "batata frita.jpg", "Onion Rings Cheddar", 16.00m },
                    { 30, 11, "Porção média com molho picante", "batata frita.jpg", "Onion Rings Picante", 15.00m },
                    { 31, 12, "Truffle Burger + Batata Grande + Bebida Premium", "ComboCapa.png", "Combo Truffle", 45.99m },
                    { 32, 12, "Bacon Cheddar + Onion Rings Grande + Suco Natural", "CombosTransparente.png", "Combo Gourmet", 42.50m },
                    { 33, 12, "Veggie Artesanal + Batata Doce + Suco Verde", "ComboCapa.png", "Combo Veggie", 38.99m },
                    { 34, 12, "Blue Cheese Burger + Batata Cheddar + Vinho", "CombosTransparente.png", "Combo Blue Cheese", 43.50m },
                    { 35, 12, "Artesanal + Batata Média + Refri 600ml", "ComboCapa.png", "Combo Executivo", 39.99m },
                    { 36, 13, "4 Burgers + 2 Batatas Grandes + 4 Bebidas", "CombosTransparente.png", "Combo Família 4 Pessoas", 89.99m },
                    { 37, 13, "6 Burgers + 3 Batatas Grandes + 6 Bebidas + Molhos", "ComboCapa.png", "Combo Festa", 120.00m },
                    { 38, 13, "2 Burgers Kids + Batata Pequena + 2 Sucos", "ComboCapa.png", "Combo Kids", 65.00m },
                    { 39, 13, "2 Burgers + Batata Média + 2 Bebidas", "CombosTransparente.png", "Combo Casal", 59.99m },
                    { 40, 13, "3 Burgers + 2 Batatas Médias + 3 Bebidas", "ComboCapa.png", "Combo Economia", 75.50m },
                    { 41, 14, "50ml - Picância média", "pimenta1.jpg", "Molho de Pimenta Jalapeño", 3.50m },
                    { 42, 14, "50ml - Picância forte", "pimenta2.jpg", "Molho Habanero", 4.00m },
                    { 43, 14, "50ml - Picância média", "pimenta3.jpg", "Molho de Pimenta Caiena", 3.50m },
                    { 44, 14, "50ml - Picância suave com sabor defumado", "pimenta4.jpg", "Molho Chipotle", 4.50m },
                    { 45, 14, "50ml - Extremamente picante", "pimenta1.jpg", "Molho Inferno", 5.00m },
                    { 46, 15, "50ml - Sofisticado com toque de trufas", "pimenta2.jpg", "Molho Trufado", 6.00m },
                    { 47, 15, "50ml - Blend de 3 queijos", "pimenta3.jpg", "Molho de Queijos", 5.00m },
                    { 48, 15, "50ml - Barbecue com whisky bourbon", "pimenta4.jpg", "Molho Barbecue Bourbon", 5.50m },
                    { 49, 15, "50ml - Exclusivo alho fermentado", "pimenta2.jpg", "Molho de Alho Negro", 6.50m },
                    { 50, 15, "50ml - Clássico molho caesar", "pimenta1.jpg", "Molho Caesar", 4.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Variations_ProductId",
                table: "Variations",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Variations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
