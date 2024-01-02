namespace Proiect_MDP_Web.Models
{
    public class Magazin
    {
        public int ID { get; set; }
        public string DenumireMagazin { get; set; }
        public ICollection<Racheta>? Rachete { get; set; } // navigation property
    }
}
