namespace Proiect_MDP_Web.Models
{
    public class RachetaData
    {
        public IEnumerable<Racheta> Rachete { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieRacheta> CategoriiRacheta { get; set; }

    }
}
