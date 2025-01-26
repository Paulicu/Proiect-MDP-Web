using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Proiect_MDP_Web.Models
{
    public class Racheta
    {
        public int ID { get; set; }

        [Display(Name = "Nume Racheta")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Numele rachetei trebuie să aibă între 3 și 150 de caractere.")]
        public string Denumire { get; set; }

        public string Material { get; set; }

        public string Tehnologie { get; set; }

        [Display(Name = "Greutate (g)")]
        public int Greutate { get; set; }

        [Display(Name = "Dimensiune Cap (cm2)")]
        public int DimensiuneCap { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 2000)]
        public decimal Pret {  get; set; }

        [DataType(DataType.Date)]
        public DateTime Editie { get; set; }

        public int? MagazinID { get; set; }
        public Magazin? Magazin { get; set; } // navigation property

        public int? FirmaID { get; set; }
        public Firma? Firma { get; set; } // navigation property

        [Display(Name = "Categorii")]
        public ICollection<CategorieRacheta>? CategoriiRacheta { get; set; }
    }
}
