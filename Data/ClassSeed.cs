namespace TotemPWA.Models
{
    public class CategorySeed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        public List<CategorySeed>? Subcategories { get; set; }
        public List<ProductSeed>? Products { get; set; }
    }

    public class ProductSeed
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Foto { get; set; } = "";
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public List<CompositionSeed>? Compositions { get; set; }
    }

    public class ComboSeed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class ComboProductSeed
    {
        public int Id { get; set; }
        public int ComboId { get; set; }
        public Combo? Combo { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }


    public class IngredientSeed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Foto { get; set; } = string.Empty;
        public decimal AdditionalPrice { get; set; }

        public List<CompositionSeed>? Compositions { get; set; }
    }

    public class CompositionSeed
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public decimal PrecoAdicional { get; set; }
        public int MaxQuantity { get; set; }

        public int ProductId { get; set; }
        public int IngredientId { get; set; }
    }

    public class UserSeed
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}