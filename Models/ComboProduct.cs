using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotemPWA.Models
{
    public class ComboProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Combo")]
        public int ComboId { get; set; }
        public Combo? Combo { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
