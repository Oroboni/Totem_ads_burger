// Define a entidade Categoria, que pode ter subcategorias e produtos.
using System.Text.Json.Serialization;
using TotemPWA.Models;

public class Category
{
    // Identificador único da categoria (chave primária).
    public int Id { get; set; }

    // Nome da categoria (obrigatório).
    public required string Name { get; set; }

    // Referência opcional à categoria pai.
    public int? ParentCategoryId { get; set; }

    // Objeto da categoria pai. Ignorado no JSON para evitar loops de serialização.
    [JsonIgnore]
    public Category? ParentCategory { get; set; }

    // Lista de subcategorias relacionadas a esta categoria.
    public ICollection<Category> Subcategories { get; set; } = new List<Category>();

    // Lista de produtos que pertencem a esta categoria.
    public ICollection<Product> Products { get; set; } = new List<Product>();
}