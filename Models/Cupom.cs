
using System.ComponentModel.DataAnnotations;

namespace TotemPWA.Models
{
    public class Cupom
    {
        [Key]
        public required string Codigo { get; set; }
        [Required]
        public required decimal Desconto { get; set; }
    }
}