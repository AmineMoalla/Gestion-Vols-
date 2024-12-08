using System.ComponentModel.DataAnnotations;

namespace GestionVols.Models
{
    public class Avion
    {
        [Key]
        public int IdAvion { get; set; }
        public string TypeAvion { get; set; }
        [Required]
        public int CapaciteAvion { get; set; }
        public string FabriquantAvion { get; set; }
        
    }
}
