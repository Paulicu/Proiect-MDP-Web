namespace Proiect_MDP_Web.Models
{
    public class CategorieRacheta
    {
        public int ID { get; set; }
        public int RachetaID { get; set; }
        public Racheta Racheta { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
