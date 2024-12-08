using System.ComponentModel.DataAnnotations;

namespace GestionVols.Models
{
    public class Passager
    {
        [Key]
        public int IdPassager { get; set; }
        [Required]
        public string NomPassager { get; set; }
        [Required]
        public string PrenomPassager  { get; set;}
        [Required]
        public string EmailPassager { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        public string TelephonePassager { get; set; }
        [Required]
        public string NumeroPasseport { get; set; }
    }
}
