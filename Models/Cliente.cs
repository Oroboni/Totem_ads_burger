
using System.ComponentModel.DataAnnotations;

namespace TotemPWA.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }
        [Required]
        public required string CPF { get; set; }
        
    }
}