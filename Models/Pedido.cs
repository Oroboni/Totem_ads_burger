using System.ComponentModel.DataAnnotations;
namespace TotemPWA.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string IdPedido { get; set; } = "";
        public decimal Total { get; set; }
        public string Local { get; set; } = "";
        public string CPF { get; set; } = "";
        public List<ItemPedido> Itens { get; set; } = new();
    }

    public class ItemPedido
    {
        public int Id { get; set; }
        public string ProdutoId { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public int Quantidade { get; set; }
        public decimal PrecoBase { get; set; }
        public decimal PrecoTotal { get; set; }
        public string ImagemUrl { get; set; } = "";
        public List<ItemIngrediente> Ingredientes { get; set; } = new();
        public List<ComboLanche> ComboLanches { get; set; } = new();
    }

    public class ItemIngrediente
    {
        public int Id { get; set; }
        public int IngredienteId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoAdicional { get; set; }
    }

    public class ComboLanche
    {
        public int Id { get; set; }
        public string NomeLanche { get; set; } = "";
        public List<ItemIngrediente> Ingredientes { get; set; } = new();
    }
}
