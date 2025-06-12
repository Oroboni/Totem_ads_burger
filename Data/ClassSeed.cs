public class CategorySeed
{
    public string Name { get; set; } = string.Empty;

    public string Slug { get; set; } = string.Empty;
    public List<CategorySeed>? Subcategories { get; set; }
    public List<ProductSeed>? Products { get; set; }
}

public class ProductSeed
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string Foto { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal AdditionalPrice { get; set; }

    public ICollection<Composition> Composition { get; set; } = new List<Composition>();
}

public class Composition
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public decimal PrecoAdicional { get; set; }

    public int MaxQuantity { get; set; }
    public int ProductId { get; set; }
    public ProductSeed? Product { get; set; } = null!;
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; } = null!;
}
