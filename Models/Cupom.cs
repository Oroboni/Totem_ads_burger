using System.ComponentModel.DataAnnotations;
using TotemPWA.Models;

namespace TotemPWA.Models
{
    public enum CupomType
    {
        Porcentagem,
        ValorFixo
    }

    public class Cupom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Codigo { get; set; }

        [Required]
        public required decimal Desconto { get; set; }

        [Required]
        public CupomType Type { get; set; }
    }
}