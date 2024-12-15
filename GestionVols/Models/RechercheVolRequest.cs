namespace GestionVols.Models
{
    public class RechercheVolRequest
    {


        public string typeVol { get; set; }  
        public string Depart { get; set; }
        public string Destination { get; set; }
        public DateTime? DateDepart{ get; set; }
        public DateTime? DateRetour { get; set; }  
        public int NbreVoyageurs { get; set; }
        public string ClassVol { get; set; }
    }
}
