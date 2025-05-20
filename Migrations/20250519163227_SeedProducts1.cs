using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TotemPWA.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 12, "Combos Premium", 2 },
                    { 13, "Combos Familiares", 2 },
                    { 14, "Molhos Picantes", 5 },
                    { 15, "Molhos Especiais", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Pão brioche, blend artesanal, queijo cheddar", "Cheeseburger Artesanal", 18.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 6, "Pão australiano, bacon crocante, cheddar derretido", "Bacon Cheddar", 21.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 6, "Pão de parmesão, carne 180g, molho blue cheese", "Blue Cheese Burger", 22.50m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 6, "Pão pretzel, trufas, queijo gruyère", "Truffle Burger", 24.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 6, "Pão integral, hambúrguer de grão-de-bico", "Veggie Artesanal", 19.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 6, 7, "Pão, carne, queijo e molho especial", "Cheeseburger Clássico", 15.99m },
                    { 7, 7, "Pão, carne, queijo, presunto e salada", "X-Burger", 16.50m },
                    { 8, 7, "Pão, carne, queijo, bacon e salada", "X-Bacon", 18.50m },
                    { 9, 7, "Pão, carne, queijo, ovo e salada", "X-Egg", 17.50m },
                    { 10, 7, "Pão, 2 carnes, queijo, bacon, ovo e salada", "X-Tudo", 20.99m },
                    { 11, 8, "350ml", "Coca-Cola Lata", 6.00m },
                    { 12, 8, "350ml", "Guaraná Antarctica", 5.50m },
                    { 13, 8, "350ml", "Fanta Laranja", 5.50m },
                    { 14, 8, "350ml", "Sprite", 5.50m },
                    { 15, 8, "Garrafa 600ml", "Coca-Cola 600ml", 8.00m },
                    { 16, 9, "Natural 500ml", "Suco de Laranja", 10.00m },
                    { 17, 9, "Natural 500ml", "Suco de Abacaxi", 10.00m },
                    { 18, 9, "Natural 500ml", "Suco de Morango", 12.00m },
                    { 19, 9, "Natural 500ml", "Suco de Maracujá", 12.00m },
                    { 20, 9, "Couve, abacaxi e gengibre 500ml", "Suco Verde", 12.50m },
                    { 21, 10, "Porção pequena", "Batata Frita Pequena", 8.00m },
                    { 22, 10, "Porção média", "Batata Frita Média", 12.00m },
                    { 23, 10, "Porção grande", "Batata Frita Grande", 16.00m },
                    { 24, 10, "Porção média com cheddar e bacon", "Batata Cheddar e Bacon", 18.00m },
                    { 25, 10, "Porção média de batata doce", "Batata Doce", 14.00m },
                    { 26, 11, "Porção pequena", "Onion Rings Pequena", 10.00m },
                    { 27, 11, "Porção média", "Onion Rings Média", 14.00m },
                    { 28, 11, "Porção grande", "Onion Rings Grande", 18.00m },
                    { 29, 11, "Porção média com cheddar", "Onion Rings Cheddar", 16.00m },
                    { 30, 11, "Porção média com molho picante", "Onion Rings Picante", 15.00m },
                    { 31, 12, "Truffle Burger + Batata Grande + Bebida Premium", "Combo Truffle", 45.99m },
                    { 32, 12, "Bacon Cheddar + Onion Rings Grande + Suco Natural", "Combo Gourmet", 42.50m },
                    { 33, 12, "Veggie Artesanal + Batata Doce + Suco Verde", "Combo Veggie", 38.99m },
                    { 34, 12, "Blue Cheese Burger + Batata Cheddar + Vinho", "Combo Blue Cheese", 43.50m },
                    { 35, 12, "Artesanal + Batata Média + Refri 600ml", "Combo Executivo", 39.99m },
                    { 36, 13, "4 Burgers + 2 Batatas Grandes + 4 Bebidas", "Combo Família 4 Pessoas", 89.99m },
                    { 37, 13, "6 Burgers + 3 Batatas Grandes + 6 Bebidas + Molhos", "Combo Festa", 120.00m },
                    { 38, 13, "2 Burgers Kids + Batata Pequena + 2 Sucos", "Combo Kids", 65.00m },
                    { 39, 13, "2 Burgers + Batata Média + 2 Bebidas", "Combo Casal", 59.99m },
                    { 40, 13, "3 Burgers + 2 Batatas Médias + 3 Bebidas", "Combo Economia", 75.50m },
                    { 41, 14, "50ml - Picância média", "Molho de Pimenta Jalapeño", 3.50m },
                    { 42, 14, "50ml - Picância forte", "Molho Habanero", 4.00m },
                    { 43, 14, "50ml - Picância média", "Molho de Pimenta Caiena", 3.50m },
                    { 44, 14, "50ml - Picância suave com sabor defumado", "Molho Chipotle", 4.50m },
                    { 45, 14, "50ml - Extremamente picante", "Molho Inferno", 5.00m },
                    { 46, 15, "50ml - Sofisticado com toque de trufas", "Molho Trufado", 6.00m },
                    { 47, 15, "50ml - Blend de 3 queijos", "Molho de Queijos", 5.00m },
                    { 48, 15, "50ml - Barbecue com whisky bourbon", "Molho Barbecue Bourbon", 5.50m },
                    { 49, 15, "50ml - Exclusivo alho fermentado", "Molho de Alho Negro", 6.50m },
                    { 50, 15, "50ml - Clássico molho caesar", "Molho Caesar", 4.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Pão, carne, queijo e molho especial", "Cheeseburger", 15.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 2, "Cheeseburger + Batata + Refrigerante", "Combo Cheeseburger", 25.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 8, "350ml", "Refrigerante Lata", 6.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 10, "Porção média", "Batata Frita", 8.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { 5, "Molho especial barbecue", "Molho Barbecue", 2.00m });
        }
    }
}
