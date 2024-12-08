using System.ComponentModel.DataAnnotations;

namespace GestionVols.Models
{
    public class Aeroport
    {
        [Key]
        public int IdAeroport{ get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Au moins 5 caractéres")]
         
        public string NomAeroport{ get; set; }
        [Required]
        public string VilleAeroport { get; set; }
        [Required]
        public string PaysAeroport { get; set; }

    }
}
