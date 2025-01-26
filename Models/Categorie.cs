using System.ComponentModel.DataAnnotations;

namespace Proiect_MDP_Web.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Categorie")]
        public string DenumireCategorie { get; set; }
        public ICollection<CategorieRacheta>? CategoriiRacheta { get; set; }
    }
}
