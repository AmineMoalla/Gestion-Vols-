namespace GestionVols.Models
{
    public class RechercheVolRequest
    {


     
        public string? Depart { get; set; }
        public string? Destination { get; set; }
        public DateTime? DateDepart{ get; set; }
        public DateTime? DateRetour { get; set; }  

        //ma sta3mlthomsh f search 
        public int? NbreVoyageurs { get; set; }
        public string? ClassVol { get; set; }
        public string? typeVol { get; set; }
    }

}
