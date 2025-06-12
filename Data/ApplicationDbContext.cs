using Microsoft.EntityFrameworkCore;
using TotemPWA.Models;

namespace TotemPWA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Composition> Compositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define self-referencing relationship for Category
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);  // Allow parent category to be null

            // Define 1-to-many relationship between Product and Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Composition>()
                .HasOne(c => c.Ingredient)
                .WithMany()
                .HasForeignKey(c => c.IngredientId);

            modelBuilder.Entity<Composition>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Compositions)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade); 



            modelBuilder.Entity<Category>().HasData(
     // Categorias principais (existentes)
     new Category { Id = 1, Name = "Burgers", ParentCategoryId = null },
     new Category { Id = 2, Name = "Combos", ParentCategoryId = null },
     new Category { Id = 3, Name = "Bebidas", ParentCategoryId = null },
     new Category { Id = 4, Name = "Acompanhamentos", ParentCategoryId = null },
     new Category { Id = 5, Name = "Molhos", ParentCategoryId = null },

     // Subcategorias existentes (mantidas)
     new Category { Id = 6, Name = "Artesanais", ParentCategoryId = 1 },
     new Category { Id = 7, Name = "Tradicionais", ParentCategoryId = 1 },
     new Category { Id = 8, Name = "Refrigerantes", ParentCategoryId = 3 },
     new Category { Id = 9, Name = "Sucos", ParentCategoryId = 3 },
     new Category { Id = 10, Name = "Batatas", ParentCategoryId = 4 },
     new Category { Id = 11, Name = "Onion Rings", ParentCategoryId = 4 },

     // NOVAS SUBCATEGORIAS (2 para cada categoria principal que tinha menos de 2)

     // Para Combos (categoria 2)
     new Category { Id = 12, Name = "Combos Premium", ParentCategoryId = 2 },
     new Category { Id = 13, Name = "Combos Familiares", ParentCategoryId = 2 },

     // Para Molhos (categoria 5)
     new Category { Id = 14, Name = "Molhos Picantes", ParentCategoryId = 5 },
     new Category { Id = 15, Name = "Molhos Especiais", ParentCategoryId = 5 }
 );

            modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Cheeseburger Artesanal", CategoryId = 6, Price = 18.99m, Description = "Pão brioche, blend artesanal, queijo cheddar", Foto = "burguerI.jpg" },
            new Product { Id = 2, Name = "Bacon Cheddar", CategoryId = 6, Price = 21.99m, Description = "Pão australiano, bacon crocante, cheddar derretido", Foto = "burguerII.jpg" },
            new Product { Id = 3, Name = "Blue Cheese Burger", CategoryId = 6, Price = 22.50m, Description = "Pão de parmesão, carne 180g, molho blue cheese", Foto = "burguerIII.jpg" },
            new Product { Id = 4, Name = "Truffle Burger", CategoryId = 6, Price = 24.99m, Description = "Pão pretzel, trufas, queijo gruyère", Foto = "buguer404.png" },
            new Product { Id = 5, Name = "Veggie Artesanal", CategoryId = 6, Price = 19.99m, Description = "Pão integral, hambúrguer de grão-de-bico", Foto = "veggie.jpg" },

            new Product { Id = 6, Name = "Cheeseburger Clássico", CategoryId = 7, Price = 15.99m, Description = "Pão, carne, queijo e molho especial", Foto = "veggie.jpg" },
            new Product { Id = 7, Name = "X-Burger", CategoryId = 7, Price = 16.50m, Description = "Pão, carne, queijo, presunto e salada", Foto = "veggie.jpg" },
            new Product { Id = 8, Name = "X-Bacon", CategoryId = 7, Price = 18.50m, Description = "Pão, carne, queijo, bacon e salada", Foto = "veggie.jpg" },
            new Product { Id = 9, Name = "X-Egg", CategoryId = 7, Price = 17.50m, Description = "Pão, carne, queijo, ovo e salada", Foto = "veggie.jpg" },
            new Product { Id = 10, Name = "X-Tudo", CategoryId = 7, Price = 20.99m, Description = "Pão, 2 carnes, queijo, bacon, ovo e salada", Foto = "veggie.jpg" },

            new Product { Id = 11, Name = "Coca-Cola Lata", CategoryId = 8, Price = 6.00m, Description = "350ml", Foto = "coca.webp" },
            new Product { Id = 12, Name = "Guaraná Antarctica", CategoryId = 8, Price = 5.50m, Description = "350ml", Foto = "gurana.jpg" },
            new Product { Id = 13, Name = "Fanta Laranja", CategoryId = 8, Price = 5.50m, Description = "350ml", Foto = "Fanta-Laranja.webp" },
            new Product { Id = 14, Name = "Sprite", CategoryId = 8, Price = 5.50m, Description = "350ml", Foto = "sprite.webp" },
            new Product { Id = 15, Name = "Coca-Cola 600ml", CategoryId = 8, Price = 8.00m, Description = "Garrafa 600ml", Foto = "coca600.webp" },

            new Product { Id = 16, Name = "Suco de Laranja", CategoryId = 9, Price = 10.00m, Description = "Natural 500ml", Foto = "coca.webp" },
            new Product { Id = 17, Name = "Suco de Abacaxi", CategoryId = 9, Price = 10.00m, Description = "Natural 500ml", Foto = "coca.webp" },
            new Product { Id = 18, Name = "Suco de Morango", CategoryId = 9, Price = 12.00m, Description = "Natural 500ml", Foto = "coca.webp" },
            new Product { Id = 19, Name = "Suco de Maracujá", CategoryId = 9, Price = 12.00m, Description = "Natural 500ml", Foto = "coca.webp" },
            new Product { Id = 20, Name = "Suco Verde", CategoryId = 9, Price = 12.50m, Description = "Couve, abacaxi e gengibre 500ml", Foto = "coca.webp" },

            new Product { Id = 21, Name = "Batata Frita Pequena", CategoryId = 10, Price = 8.00m, Description = "Porção pequena", Foto = "batata frita.jpg" },
            new Product { Id = 22, Name = "Batata Frita Média", CategoryId = 10, Price = 12.00m, Description = "Porção média", Foto = "batata frita.jpg" },
            new Product { Id = 23, Name = "Batata Frita Grande", CategoryId = 10, Price = 16.00m, Description = "Porção grande", Foto = "batata frita.jpg" },
            new Product { Id = 24, Name = "Batata Cheddar e Bacon", CategoryId = 10, Price = 18.00m, Description = "Porção média com cheddar e bacon", Foto = "batata frita.jpg" },
            new Product { Id = 25, Name = "Batata Doce", CategoryId = 10, Price = 14.00m, Description = "Porção média de batata doce", Foto = "batatadoce.webp" },

            new Product { Id = 26, Name = "Onion Rings Pequena", CategoryId = 11, Price = 10.00m, Description = "Porção pequena", Foto = "batata frita.jpg" },
            new Product { Id = 27, Name = "Onion Rings Média", CategoryId = 11, Price = 14.00m, Description = "Porção média", Foto = "batata frita.jpg" },
            new Product { Id = 28, Name = "Onion Rings Grande", CategoryId = 11, Price = 18.00m, Description = "Porção grande", Foto = "batata frita.jpg" },
            new Product { Id = 29, Name = "Onion Rings Cheddar", CategoryId = 11, Price = 16.00m, Description = "Porção média com cheddar", Foto = "batata frita.jpg" },
            new Product { Id = 30, Name = "Onion Rings Picante", CategoryId = 11, Price = 15.00m, Description = "Porção média com molho picante", Foto = "batata frita.jpg" },

            new Product { Id = 31, Name = "Combo Truffle", CategoryId = 12, Price = 45.99m, Description = "Truffle Burger + Batata Grande + Bebida Premium", Foto = "ComboCapa.png" },
            new Product { Id = 32, Name = "Combo Gourmet", CategoryId = 12, Price = 42.50m, Description = "Bacon Cheddar + Onion Rings Grande + Suco Natural", Foto = "CombosTransparente.png" },
            new Product { Id = 33, Name = "Combo Veggie", CategoryId = 12, Price = 38.99m, Description = "Veggie Artesanal + Batata Doce + Suco Verde", Foto = "ComboCapa.png" },
            new Product { Id = 34, Name = "Combo Blue Cheese", CategoryId = 12, Price = 43.50m, Description = "Blue Cheese Burger + Batata Cheddar + Vinho", Foto = "CombosTransparente.png" },
            new Product { Id = 35, Name = "Combo Executivo", CategoryId = 12, Price = 39.99m, Description = "Artesanal + Batata Média + Refri 600ml", Foto = "ComboCapa.png" },

            new Product { Id = 36, Name = "Combo Família 4 Pessoas", CategoryId = 13, Price = 89.99m, Description = "4 Burgers + 2 Batatas Grandes + 4 Bebidas", Foto = "CombosTransparente.png" },
            new Product { Id = 37, Name = "Combo Festa", CategoryId = 13, Price = 120.00m, Description = "6 Burgers + 3 Batatas Grandes + 6 Bebidas + Molhos", Foto = "ComboCapa.png" },
            new Product { Id = 38, Name = "Combo Kids", CategoryId = 13, Price = 65.00m, Description = "2 Burgers Kids + Batata Pequena + 2 Sucos", Foto = "ComboCapa.png" },
            new Product { Id = 39, Name = "Combo Casal", CategoryId = 13, Price = 59.99m, Description = "2 Burgers + Batata Média + 2 Bebidas", Foto = "CombosTransparente.png" },
            new Product { Id = 40, Name = "Combo Economia", CategoryId = 13, Price = 75.50m, Description = "3 Burgers + 2 Batatas Médias + 3 Bebidas", Foto = "ComboCapa.png" },

            new Product { Id = 41, Name = "Molho de Pimenta Jalapeño", CategoryId = 14, Price = 3.50m, Description = "50ml - Picância média", Foto = "pimenta1.jpg" },
            new Product { Id = 42, Name = "Molho Habanero", CategoryId = 14, Price = 4.00m, Description = "50ml - Picância forte", Foto = "pimenta2.jpg" },
            new Product { Id = 43, Name = "Molho de Pimenta Caiena", CategoryId = 14, Price = 3.50m, Description = "50ml - Picância média", Foto = "pimenta3.jpg" },
            new Product { Id = 44, Name = "Molho Chipotle", CategoryId = 14, Price = 4.50m, Description = "50ml - Picância suave com sabor defumado", Foto = "pimenta4.jpg" },
            new Product { Id = 45, Name = "Molho Inferno", CategoryId = 14, Price = 5.00m, Description = "50ml - Extremamente picante", Foto = "pimenta1.jpg" },

            new Product { Id = 46, Name = "Molho Trufado", CategoryId = 15, Price = 6.00m, Description = "50ml - Sofisticado com toque de trufas", Foto = "pimenta2.jpg" },
            new Product { Id = 47, Name = "Molho de Queijos", CategoryId = 15, Price = 5.00m, Description = "50ml - Blend de 3 queijos", Foto = "pimenta3.jpg" },
            new Product { Id = 48, Name = "Molho Barbecue Bourbon", CategoryId = 15, Price = 5.50m, Description = "50ml - Barbecue com whisky bourbon", Foto = "pimenta4.jpg" },
            new Product { Id = 49, Name = "Molho de Alho Negro", CategoryId = 15, Price = 6.50m, Description = "50ml - Exclusivo alho fermentado", Foto = "pimenta2.jpg" },
            new Product { Id = 50, Name = "Molho Caesar", CategoryId = 15, Price = 4.50m, Description = "50ml - Clássico molho caesar", Foto = "pimenta1.jpg" }
        );


            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Bacon", AdditionalPrice = 2.00m },
                new Ingredient { Id = 2, Name = "Queijo Extra", AdditionalPrice = 1.50m },
                new Ingredient { Id = 3, Name = "Ovo", AdditionalPrice = 1.00m },
                new Ingredient { Id = 4, Name = "Cebola Caramelizada", AdditionalPrice = 1.20m },
                new Ingredient { Id = 5, Name = "Pimenta Jalapeño", AdditionalPrice = 0.80m }
            );

            modelBuilder.Entity<Composition>().HasData(
                new Composition { Id = 1, MaxQuantity = 1, IngredientId = 1, ProductId = 1 },
                new Composition { Id = 2, MaxQuantity = 1, IngredientId = 2, ProductId = 1 },
                new Composition { Id = 3, MaxQuantity = 1, IngredientId = 3, ProductId = 2 },
                new Composition { Id = 4, MaxQuantity = 1, IngredientId = 4, ProductId = 2 },
                new Composition { Id = 5, MaxQuantity = 1, IngredientId = 5, ProductId = 3 }
            );
            // dotnet ef migrations add SeedProducts
            // dotnet ef database update

        }
    }
}
