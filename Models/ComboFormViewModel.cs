using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotemPWA.Models
{
    public class ComboFormViewModel
    {

        public Combo Combo { get; set; } = new Combo();
        public List<int> SelectedProductIds { get; set; } = new List<int>();
    }
    
}