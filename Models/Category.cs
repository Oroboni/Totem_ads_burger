using System.Text.Json.Serialization;
using TotemPWA.Models;
using System.Text.RegularExpressions;

public class Category
{
    public int Id { get; set; }

    private string _name = string.Empty;
    public required string Name
    {
        get => _name;
        set
        { 
            _name = value;
            Slug = GenerateSlug(value); // Gera o slug quando o nome é definido
        }

    }

    public string Slug { get; set; } = string.Empty;

    private string GenerateSlug(string text)
    {
        text = text.ToLowerInvariant().Trim();                         // Converte para minúsculas e remove espaços no início/fim
        text = Regex.Replace(text, @"[^a-z0-9\s-]", "");               // Remove caracteres especiais
        text = Regex.Replace(text, @"\s+", "-");                       // Substitui espaços por hífens
        text = Regex.Replace(text, @"-+", "-");                        // Remove múltiplos hífens consecutivos
        return text;
    }
    public int? ParentCategoryId { get; set; }

    [JsonIgnore]
    public Category? ParentCategory { get; set; }

    public ICollection<Category> Subcategories { get; set; } = new List<Category>();

    public ICollection<Product> Products { get; set; } = new List<Product>();
}