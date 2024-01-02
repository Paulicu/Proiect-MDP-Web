namespace Proiect_MDP_Web.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string DenumireCategorie { get; set; }
        public ICollection<CategorieRacheta>? CategoriiRacheta { get; set; }
    }
}
