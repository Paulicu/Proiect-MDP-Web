namespace Proiect_MDP_Web.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Racheta> Rachete { get; set; }
        public IEnumerable<CategorieRacheta> CategoriiRacheta { get; set; }
    }
}
