using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionVols.Models
{
    public class Vol
    {
        [Key]
        public int IdVol { get; set; }
        [Required]
        public string NumeroVol { get; set; }      
     
        public DateTime HeureDepart { get; set; }
        public DateTime HeureArrivee { get; set; }
        public string Statut { get; set; }
        public string Porte { get; set; }  //gate
        public string TypeAvion { get; set; }

        [ForeignKey(nameof(AeroportDepart))]
        public int IdAeroportDepart { get; set; }

        [ForeignKey(nameof(AeroportArrivee))]
        public int IdAeroportArrivee { get; set; } 
         public  Aeroport? AeroportDepart { get; set; }
         public  Aeroport? AeroportArrivee { get; set; }

        [ForeignKey(nameof(Avion))]

        public int? IdAvion { get; set; }
        public Avion? Avion { get; set; }

        public int NbreReservée { get; set; }

    }
}