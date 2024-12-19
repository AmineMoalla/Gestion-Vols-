using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVols.Models
{
    public class Offre
    {
        [Key]
        public int IdOffre { get; set; }

        [Required]
        public string NomOffre { get; set; }

        [Required]
        public decimal PourcentageReduction { get; set; } // Exemple : 10% = 0.10

        [ForeignKey(nameof(Vol))]
        public int IdVol { get; set; }
        public Vol Vol { get; set; }
    }
}
