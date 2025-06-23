namespace TotemPWA.Models
{
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
        public string Name { get; set; } = "";
        public string Foto { get; set; } = "";
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public List<CompositionSeed>? Compositions { get; set; }
    }

    public class IngredientSeed
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
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
    public class CupomSeed
    {
        public string Codigo { get; set; } = string.Empty;
        public decimal Desconto { get; set; }
    }
}