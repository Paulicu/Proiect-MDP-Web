using System.ComponentModel.DataAnnotations;

namespace Proiect_MDP_Web.Models
{
    public class Magazin
    {
        public int ID { get; set; }

        [Display(Name = "Nume Magazin")]
        public string DenumireMagazin { get; set; }
        public ICollection<Racheta>? Rachete { get; set; } // navigation property
    }
}
