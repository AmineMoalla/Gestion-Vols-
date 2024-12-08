using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GestionVols.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; } 

        [Required]
        public int IdPassager { get; set; } 

        [ForeignKey("IdPassager")]
        public Passager Passager { get; set; } 

        [Required]
        public int IdVol { get; set; } 

        [ForeignKey("IdVol")]
        public Vol Vol { get; set; } 

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateReservation { get; set; }  

        [Required]
        public string StatutReservation { get; set; } 
        [Required]
        public decimal PrixReservation { get; set; } 
    }
}
