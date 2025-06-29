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
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboProduct> ComboProducts { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<ComboProduct>()
                .HasOne(cp => cp.Combo)
                .WithMany(c => c.ComboProducts)
                .HasForeignKey(cp => cp.ComboId);

            modelBuilder.Entity<ComboProduct>()
                .HasOne(cp => cp.Product)
                .WithMany()
                .HasForeignKey(cp => cp.ProductId);

            modelBuilder.Entity<Combo>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Combo>()
                .HasMany(c => c.ComboProducts)
                .WithOne(cp => cp.Combo)
                .HasForeignKey(cp => cp.ComboId);




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
                new Product { Id = 1, Name = "Cheeseburger Artesanal", CategoryId = 6, Price = 11.10m, Description = "Pão brioche, blend artesanal, queijo cheddar", Foto = "burguerI.jpg" },
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
                new Ingredient { Id = 1, Name = "Bacon", AdditionalPrice = 2.00m, Foto = "https://purepng.com/public/uploads/large/purepng.com-baconfood-meat-fried-pork-cooked-941524619205lmptp.png" },
                new Ingredient { Id = 2, Name = "Queijo", AdditionalPrice = 1.50m, Foto = "https://www.pngmart.com/files/16/Cheese-Piece-Slice-PNG-Clipart.png" },
                new Ingredient { Id = 3, Name = "alface", AdditionalPrice = 1.00m, Foto = "https://th.bing.com/th/id/R.e8b9516fa28fb9bd627f165702a56d6e?rik=hLa5GIL15ybojw&pid=ImgRaw&r=0" },
                new Ingredient { Id = 4, Name = "tomate", AdditionalPrice = 1.20m, Foto = "https://th.bing.com/th/id/R.0e88ac13dc38fd380591cf4dc357f709?rik=bigMcONgbIcfTA&riu=http%3a%2f%2fwww.pngall.com%2fwp-content%2fuploads%2f2016%2f04%2fTomato-Free-PNG-Image.png&ehk=TnfBtAyfzAetFPKm1B71hlBLCWT%2fIOfh961OOEmsejg%3d&risl=&pid=ImgRaw&r=0" },
                new Ingredient { Id = 5, Name = "Hamburger", AdditionalPrice = 0.80m, Foto = "https://laretofood.hr/wp-content/uploads/2024/04/ROUNDEES-deciso-industria-min-600x600.png" }
            );

            modelBuilder.Entity<Combo>().HasData(
                new Combo { Id = 31, Name = "Combo Truffle", CategoryId = 12, Price = 45.99m, Description = "Truffle Burger + Batata Grande + Bebida Premium", Foto = "ComboCapa.png" },
                new Combo { Id = 32, Name = "Combo Gourmet", CategoryId = 12, Price = 42.5m, Description = "Bacon Cheddar + Onion Rings Grande + Suco Natural", Foto = "CombosTransparente.png" },
                new Combo { Id = 33, Name = "Combo Veggie", CategoryId = 12, Price = 38.99m, Description = "Veggie Artesanal + Batata Doce + Suco Verde", Foto = "ComboCapa.png" },
                new Combo { Id = 34, Name = "Combo Blue Cheese", CategoryId = 12, Price = 43.5m, Description = "Blue Cheese Burger + Batata Cheddar + Vinho", Foto = "CombosTransparente.png" },
                new Combo { Id = 35, Name = "Combo Executivo", CategoryId = 12, Price = 39.99m, Description = "Artesanal + Batata Média + Refri 600ml", Foto = "ComboCapa.png" },
                new Combo { Id = 36, Name = "Combo Família 4 Pessoas", CategoryId = 13, Price = 89.99m, Description = "4 Burgers + 2 Batatas Grandes + 4 Bebidas", Foto = "CombosTransparente.png" },
                new Combo { Id = 37, Name = "Combo Festa", CategoryId = 13, Price = 120.0m, Description = "6 Burgers + 3 Batatas Grandes + 6 Bebidas + Molhos", Foto = "ComboCapa.png" },
                new Combo { Id = 38, Name = "Combo Kids", CategoryId = 13, Price = 65.0m, Description = "2 Burgers Kids + Batata Pequena + 2 Sucos", Foto = "ComboCapa.png" },
                new Combo { Id = 39, Name = "Combo Casal", CategoryId = 13, Price = 59.99m, Description = "2 Burgers + Batata Média + 2 Bebidas", Foto = "CombosTransparente.png" },
                new Combo { Id = 40, Name = "Combo Economia", CategoryId = 13, Price = 75.5m, Description = "3 Burgers + 2 Batatas Médias + 3 Bebidas", Foto = "ComboCapa.png" }
            );


            modelBuilder.Entity<ComboProduct>().HasData(
                // Combo 1 - Combo Truffle
                new ComboProduct { Id = 1, ComboId = 31, ProductId = 4 },  // Truffle Burger
                new ComboProduct { Id = 2, ComboId = 31, ProductId = 23 }, // Batata Frita Grande
                new ComboProduct { Id = 3, ComboId = 31, ProductId = 15 }, // Coca-Cola 600ml

                // Combo 2 - Combo Gourmet
                new ComboProduct { Id = 4, ComboId = 32, ProductId = 2 },  // Bacon Cheddar
                new ComboProduct { Id = 5, ComboId = 32, ProductId = 28 }, // Onion Rings Grande
                new ComboProduct { Id = 6, ComboId = 32, ProductId = 16 }, // Suco de Laranja

                // Combo 33 - Combo Veggie (corrigido!)
                new ComboProduct { Id = 7, ComboId = 33, ProductId = 5 },  // Veggie Artesanal
                new ComboProduct { Id = 8, ComboId = 33, ProductId = 25 }, // Batata Doce
                new ComboProduct { Id = 9, ComboId = 33, ProductId = 20 }, // Suco Verde

                // Combo 34 - Combo Blue Cheese
                new ComboProduct { Id = 10, ComboId = 34, ProductId = 3 },  // Blue Cheese Burger
                new ComboProduct { Id = 11, ComboId = 34, ProductId = 24 }, // Batata Cheddar e Bacon

                // Combo 35 - Combo Executivo
                new ComboProduct { Id = 12, ComboId = 35, ProductId = 1 },  // Cheeseburger Artesanal
                new ComboProduct { Id = 13, ComboId = 35, ProductId = 22 }, // Batata Frita Média
                new ComboProduct { Id = 14, ComboId = 35, ProductId = 15 }, // Coca-Cola 600ml

                // Combo 36 - Combo Família 4 Pessoas
                new ComboProduct { Id = 15, ComboId = 36, ProductId = 6 },
                new ComboProduct { Id = 16, ComboId = 36, ProductId = 6 },
                new ComboProduct { Id = 17, ComboId = 36, ProductId = 6 },
                new ComboProduct { Id = 18, ComboId = 36, ProductId = 6 },
                new ComboProduct { Id = 19, ComboId = 36, ProductId = 23 },
                new ComboProduct { Id = 20, ComboId = 36, ProductId = 23 },
                new ComboProduct { Id = 21, ComboId = 36, ProductId = 11 },
                new ComboProduct { Id = 22, ComboId = 36, ProductId = 11 },
                new ComboProduct { Id = 23, ComboId = 36, ProductId = 11 },
                new ComboProduct { Id = 24, ComboId = 36, ProductId = 11 },

                // Combo 37 - Combo Festa
                new ComboProduct { Id = 25, ComboId = 37, ProductId = 6 },
                new ComboProduct { Id = 26, ComboId = 37, ProductId = 6 },
                new ComboProduct { Id = 27, ComboId = 37, ProductId = 6 },
                new ComboProduct { Id = 28, ComboId = 37, ProductId = 6 },
                new ComboProduct { Id = 29, ComboId = 37, ProductId = 6 },
                new ComboProduct { Id = 30, ComboId = 37, ProductId = 6 },
                new ComboProduct { Id = 31, ComboId = 37, ProductId = 23 },
                new ComboProduct { Id = 32, ComboId = 37, ProductId = 23 },
                new ComboProduct { Id = 33, ComboId = 37, ProductId = 23 },
                new ComboProduct { Id = 34, ComboId = 37, ProductId = 11 },
                new ComboProduct { Id = 35, ComboId = 37, ProductId = 11 },
                new ComboProduct { Id = 36, ComboId = 37, ProductId = 11 },
                new ComboProduct { Id = 37, ComboId = 37, ProductId = 11 },
                new ComboProduct { Id = 38, ComboId = 37, ProductId = 11 },
                new ComboProduct { Id = 39, ComboId = 37, ProductId = 11 },

                // Combo 38 - Combo Kids
                new ComboProduct { Id = 40, ComboId = 38, ProductId = 6 },
                new ComboProduct { Id = 41, ComboId = 38, ProductId = 6 },
                new ComboProduct { Id = 42, ComboId = 38, ProductId = 21 },
                new ComboProduct { Id = 43, ComboId = 38, ProductId = 16 },
                new ComboProduct { Id = 44, ComboId = 38, ProductId = 16 },

                // Combo 39 - Combo Casal
                new ComboProduct { Id = 45, ComboId = 39, ProductId = 6 },
                new ComboProduct { Id = 46, ComboId = 39, ProductId = 6 },
                new ComboProduct { Id = 47, ComboId = 39, ProductId = 22 },
                new ComboProduct { Id = 48, ComboId = 39, ProductId = 11 },
                new ComboProduct { Id = 49, ComboId = 39, ProductId = 11 },

                // Combo 40 - Combo Economia
                new ComboProduct { Id = 50, ComboId = 40, ProductId = 6 },
                new ComboProduct { Id = 51, ComboId = 40, ProductId = 6 },
                new ComboProduct { Id = 52, ComboId = 40, ProductId = 6 },
                new ComboProduct { Id = 53, ComboId = 40, ProductId = 22 },
                new ComboProduct { Id = 54, ComboId = 40, ProductId = 22 },
                new ComboProduct { Id = 55, ComboId = 40, ProductId = 11 },
                new ComboProduct { Id = 56, ComboId = 40, ProductId = 11 },
                new ComboProduct { Id = 57, ComboId = 40, ProductId = 11 }
            );



            modelBuilder.Entity<Composition>().HasData(
                // Cheeseburger Artesanal
                new Composition { Id = 1, MaxQuantity = 5, IngredientId = 1, ProductId = 1, quantity = 2 },
                new Composition { Id = 2, MaxQuantity = 5, IngredientId = 2, ProductId = 1, quantity = 3 },
                new Composition { Id = 3, MaxQuantity = 5, IngredientId = 5, ProductId = 1, quantity = 2 },
                new Composition { Id = 4, MaxQuantity = 5, IngredientId = 3, ProductId = 1, quantity = 1 },

                // Bacon Cheddar
                new Composition { Id = 5, MaxQuantity = 5, IngredientId = 1, ProductId = 2, quantity = 3 },
                new Composition { Id = 6, MaxQuantity = 5, IngredientId = 2, ProductId = 2, quantity = 2 },
                new Composition { Id = 7, MaxQuantity = 5, IngredientId = 5, ProductId = 2, quantity = 2 },
                new Composition { Id = 8, MaxQuantity = 5, IngredientId = 4, ProductId = 2, quantity = 1 },

                // Blue Cheese Burger
                new Composition { Id = 9, MaxQuantity = 5, IngredientId = 2, ProductId = 3, quantity = 3 },
                new Composition { Id = 10, MaxQuantity = 5, IngredientId = 5, ProductId = 3, quantity = 3 },
                new Composition { Id = 11, MaxQuantity = 5, IngredientId = 1, ProductId = 3, quantity = 1 },
                new Composition { Id = 12, MaxQuantity = 5, IngredientId = 3, ProductId = 3, quantity = 1 },

                // Truffle Burger
                new Composition { Id = 13, MaxQuantity = 5, IngredientId = 2, ProductId = 4, quantity = 4 },
                new Composition { Id = 14, MaxQuantity = 5, IngredientId = 5, ProductId = 4, quantity = 2 },
                new Composition { Id = 15, MaxQuantity = 5, IngredientId = 1, ProductId = 4, quantity = 2 },
                new Composition { Id = 16, MaxQuantity = 5, IngredientId = 4, ProductId = 4, quantity = 1 },

                // Veggie Artesanal
                new Composition { Id = 17, MaxQuantity = 5, IngredientId = 3, ProductId = 5, quantity = 3 },
                new Composition { Id = 18, MaxQuantity = 5, IngredientId = 4, ProductId = 5, quantity = 2 },
                new Composition { Id = 19, MaxQuantity = 5, IngredientId = 2, ProductId = 5, quantity = 1 },
                new Composition { Id = 20, MaxQuantity = 5, IngredientId = 5, ProductId = 5, quantity = 2 },

                // Cheeseburger Clássico
                new Composition { Id = 21, MaxQuantity = 5, IngredientId = 2, ProductId = 6, quantity = 3 },
                new Composition { Id = 22, MaxQuantity = 5, IngredientId = 5, ProductId = 6, quantity = 2 },
                new Composition { Id = 23, MaxQuantity = 5, IngredientId = 3, ProductId = 6, quantity = 1 },
                new Composition { Id = 24, MaxQuantity = 5, IngredientId = 4, ProductId = 6, quantity = 2 },

                // X-Burger
                new Composition { Id = 25, MaxQuantity = 5, IngredientId = 2, ProductId = 7, quantity = 2 },
                new Composition { Id = 26, MaxQuantity = 5, IngredientId = 3, ProductId = 7, quantity = 2 },
                new Composition { Id = 27, MaxQuantity = 5, IngredientId = 4, ProductId = 7, quantity = 1 },
                new Composition { Id = 28, MaxQuantity = 5, IngredientId = 5, ProductId = 7, quantity = 3 },

                // X-Bacon
                new Composition { Id = 29, MaxQuantity = 5, IngredientId = 1, ProductId = 8, quantity = 2 },
                new Composition { Id = 30, MaxQuantity = 5, IngredientId = 2, ProductId = 8, quantity = 2 },
                new Composition { Id = 31, MaxQuantity = 5, IngredientId = 3, ProductId = 8, quantity = 1 },
                new Composition { Id = 32, MaxQuantity = 5, IngredientId = 5, ProductId = 8, quantity = 3 },

                // X-Egg
                new Composition { Id = 33, MaxQuantity = 5, IngredientId = 5, ProductId = 9, quantity = 2 },
                new Composition { Id = 34, MaxQuantity = 5, IngredientId = 2, ProductId = 9, quantity = 2 },
                new Composition { Id = 35, MaxQuantity = 5, IngredientId = 3, ProductId = 9, quantity = 2 },
                new Composition { Id = 36, MaxQuantity = 5, IngredientId = 4, ProductId = 9, quantity = 1 },

                // X-Tudo
                new Composition { Id = 37, MaxQuantity = 5, IngredientId = 1, ProductId = 10, quantity = 2 },
                new Composition { Id = 38, MaxQuantity = 5, IngredientId = 2, ProductId = 10, quantity = 2 },
                new Composition { Id = 39, MaxQuantity = 5, IngredientId = 3, ProductId = 10, quantity = 2 },
                new Composition { Id = 40, MaxQuantity = 5, IngredientId = 4, ProductId = 10, quantity = 1 },
                new Composition { Id = 41, MaxQuantity = 5, IngredientId = 5, ProductId = 10, quantity = 4 }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Login = "123", Senha = "123" }
            );

            // dotnet ef migrations add SeedProducts
            // dotnet ef database update

        }
    }
}
